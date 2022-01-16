using System.Windows;
using System.Windows.Input;

namespace AccountingWorkingHours.Views;

/// <summary>
///     Логика взаимодействия для AddWorkerWindow.xaml
/// </summary>
public partial class AddWorkerWindow : Window
{
    public AddWorkerWindow() => InitializeComponent();//DataContext = (Application.Current as App)!.Host.Services.GetService<IAddPlaceWindowViewModel>();

    private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }
}