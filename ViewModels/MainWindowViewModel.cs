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

        RemovePlaceDialog = new RelayCommand((obj) =>
        {
            RemovePlaceWindow removePlaceWindow = new();
            removePlaceWindow.ShowDialog();
        });

        RemoveWorkerDialog = new RelayCommand((obj) =>
        {
            RemoveWorkerWindow removeWorkerWindow = new();
            removeWorkerWindow.ShowDialog();
        });
    }

    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
    public ICommand RemovePlaceDialog { get; }
    public ICommand RemoveWorkerDialog { get; }
}