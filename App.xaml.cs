using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AccountingWorkingHours.ViewModels;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AccountingWorkingHours;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().ConfigureServices(service =>
        {
            _ = service.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            _ = service.AddTransient<IAddPlaceWindowViewModel, AddPlaceWindowViewModes>();
            _ = service.AddSingleton<MainWindow>();
        }).UseSerilog((hostingContext, _, loggerConfiguration) => loggerConfiguration.ReadFrom
            .Configuration(hostingContext.Configuration).Enrich.FromLogContext().WriteTo
            .File("logs.log", rollingInterval: RollingInterval.Day)).Build();
    }

    public IHost Host { get; }

    protected override void OnStartup(StartupEventArgs e)
    {
        _ = CheckFolderAndFileAsync().ConfigureAwait(false);
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (Host)
        {
            await Host.StopAsync();
        }

        base.OnExit(e);
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = Host.Services.GetService<MainWindow>();
        mainWindow!.Show();
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = Host.Services.GetService<ILogger>();
        logger!.Error(e.Exception, "Произошла глобальная/необработанная ошибка");
        _ = MessageBox.Show("Произошла ошибка в работе приложения", "Критическая ошибка", MessageBoxButton.OK,
            MessageBoxImage.Error);
    }

    private static Task CheckFolderAndFileAsync()
    {
        return Task.Run(() =>
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data");
            if (!Directory.Exists(path))
                _ = Directory.CreateDirectory(path);
        });
    }
}