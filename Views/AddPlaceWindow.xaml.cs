using System.Windows;
using System.Windows.Input;
using AccountingWorkingHours.ViewModels.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingWorkingHours.Views;

/// <summary>
///     Логика взаимодействия для AddPlaceWindow.xaml
/// </summary>
public partial class AddPlaceWindow : Window
{
    public AddPlaceWindow()
    {
        InitializeComponent();
        DataContext = (Application.Current as App)!.Host.Services.GetService<IAddPlaceWindowViewModel>();
    }

    private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
}