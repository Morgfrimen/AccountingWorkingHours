﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AccountingWorkingHours.ViewModels;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AccountingWorkingHours;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly GrpcChannel _channel;

    public App()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration(builder =>
            {
                var pathJsonSettings = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
                builder.AddJsonFile(pathJsonSettings);
            })
            .ConfigureServices(service =>
            {
                _ = service.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
                _ = service.AddSingleton<MainWindow>();
            })
            .UseSerilog((hostingContext, _, loggerConfiguration) => loggerConfiguration.ReadFrom
                .Configuration(hostingContext.Configuration).Enrich.FromLogContext().WriteTo
                .File("logs.log", rollingInterval: RollingInterval.Day)).Build();
        var config = Host.Services.GetService<IConfiguration>();

        _channel = GrpcChannel.ForAddress(config.GetValue<string>("SaveService"));
    }

    private IHost Host { get; }

    protected override void OnStartup(StartupEventArgs e)
    {
        _ = CheckFolderAndFileAsync().ConfigureAwait(false);

        //TestConnection
        var testClientClient = new TestConnection.TestConnectionClient(_channel);
        var response = testClientClient.SayHello(new HelloRequest() { Name = "Запуск приложения" });
        if (response != null)
        {
            MessageBox.Show("Соединение установленно");
        }

        base.OnStartup(e);
        //_ = Task.Run(async () =>
        //{
        //    var service = Host.Services.GetService<ISaveDataService>();
        //    var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
        //    var workersSave = service!.GetWorkers();
        //    mainVm.Workers = workersSave!.Cast<WorkerModel>().ToObservableCollection();
        //    while (!_stopBackTask)
        //    {
        //        service.SaveWorkers(mainVm.Workers);
        //        await Task.Delay(new TimeSpan(0, 2, 0));
        //    }
        //});
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        _channel.Dispose();
        //using (Host)
        //{
        //    var service = Host.Services.GetService<ISaveDataService>();
        //    var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
        //    service.SaveWorkers(mainVm.Workers);
        //    await Host.StopAsync();
        //}

        base.OnExit(e);
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = Host.Services.GetService<MainWindow>();
        mainWindow!.Show();
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        _channel.Dispose();
        var logger = Host.Services.GetService<ILogger>();
        logger!.Error(e.Exception, "Произошла глобальная/необработанная ошибка");
        _ = MessageBox.Show("Произошла ошибка в работе приложения", "Критическая ошибка", MessageBoxButton.OK,
            MessageBoxImage.Error);
        var messageSave = MessageBox.Show("Сохранить данные?", "Уведомление", MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        //if (messageSave == MessageBoxResult.Yes)
        //{
        //    var service = Host.Services.GetService<ISaveDataService>();
        //    var mainVm = Host.Services.GetService<IMainWindowViewModel>()!;
        //    service.SaveWorkers(mainVm.Workers);
        //}
    }

    private static Task CheckFolderAndFileAsync() => Task.Run(() =>
                                                           {
                                                               var path = Path.Combine(Environment.CurrentDirectory, "Data");
                                                               if (!Directory.Exists(path)) _ = Directory.CreateDirectory(path);
                                                           });
}