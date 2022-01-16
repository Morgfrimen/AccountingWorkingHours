using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AccountingWorkingHours.Extension;
using AccountingWorkingHours.Mapping;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Service;
using AccountingWorkingHours.Service.Abstract;
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
    private bool _stopBackTask;

    public App() => Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().ConfigureServices(service =>
    {
        _ = service.AddAutoMapper(typeof(AutoMapperProfile));
        _ = service.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        _ = service.AddTransient<ISaveDataService, SaveDataService>();
        _ = service.AddSingleton<MainWindow>();
    }).UseSerilog((hostingContext, _, loggerConfiguration) => loggerConfiguration.ReadFrom
        .Configuration(hostingContext.Configuration).Enrich.FromLogContext().WriteTo
        .File("logs.log", rollingInterval: RollingInterval.Day)).Build();

    private IHost Host { get; }

    protected override void OnStartup(StartupEventArgs e)
    {
        _ = CheckFolderAndFileAsync().ConfigureAwait(false);
        base.OnStartup(e);
        _ = Task.Run(async () =>
        {
            var service = Host.Services.GetService<ISaveDataService>();
            var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
            var workersSave = service!.GetWorkers();
            mainVm.Workers = workersSave!.Cast<WorkerModel>().ToObservableCollection();
            while (!_stopBackTask)
            {
                service.SaveWorkers(mainVm.Workers);
                await Task.Delay(new TimeSpan(0, 2, 0));
            }
        });
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        _stopBackTask = true;
        using (Host)
        {
            var service = Host.Services.GetService<ISaveDataService>();
            var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
            service.SaveWorkers(mainVm.Workers);
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
        var messageSave = MessageBox.Show("Сохранить данные?", "Уведомление", MessageBoxButton.YesNo,
            MessageBoxImage.Question);
        if (messageSave == MessageBoxResult.Yes)
        {
            var service = Host.Services.GetService<ISaveDataService>();
            var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
            service.SaveWorkers(mainVm.Workers);
        }
    }

    private static Task CheckFolderAndFileAsync() => Task.Run(() =>
    {
        var path = Path.Combine(Environment.CurrentDirectory, "Data");
        if (!Directory.Exists(path)) _ = Directory.CreateDirectory(path);
    });
}