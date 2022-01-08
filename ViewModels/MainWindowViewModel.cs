using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;

namespace AccountingWorkingHours.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel, IMainWindowViewModel 
{
    public MainWindowViewModel()
    {
        AddPlaceDialog = new RelayCommand((obj) =>
        {
            AddPlaceWindow addPlaceWindow = new();
            addPlaceWindow.ShowDialog();
        });
    }

    public ICommand AddPlaceDialog { get; }
}