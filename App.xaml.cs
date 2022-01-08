using System.Windows;
using AccountingWorkingHours.ViewModels;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccountingWorkingHours
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(service =>
            {
                service.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
                service.AddScoped<IAddPlaceWindowViewModel, AddPlaceWindowViewModes>();

                service.AddSingleton<MainWindow>();
                service.AddSingleton<AddPlaceWindow>();
            }).Build();
        }
        
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow!.Show();
        }
    }
}
