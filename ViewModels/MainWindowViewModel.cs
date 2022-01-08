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

        AddWorkerDialog = new RelayCommand((obj) =>
        {
            AddWorkerWindow addWorkerWindow = new();
            addWorkerWindow.ShowDialog();
        });
    }

    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
}