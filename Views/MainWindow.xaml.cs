using System.Windows;
using System.Windows.Input;
using AccountingWorkingHours.ViewModels.Abstracts;
using Microsoft.Extensions.Logging;

namespace AccountingWorkingHours.Views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ILogger<MainWindow> _logger;

    public MainWindow(IMainWindowViewModel vm, ILogger<MainWindow> logger)
    {
        InitializeComponent();
        DataContext = vm;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Запуск приложения!");
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow!.WindowState = WindowState.Minimized;
    }

    private void WindowStateButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow!.WindowState =
            Application.Current.MainWindow!.WindowState is not WindowState.Maximized
                ? WindowState.Maximized
                : WindowState.Normal;
    }
}