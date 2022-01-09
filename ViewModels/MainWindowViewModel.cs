using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;

namespace AccountingWorkingHours.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
{
    private IList<IWorkerModel> _workerModels;
    private IWorkerModel? _selectedWorker;

    public MainWindowViewModel()
    {
        AddPlaceDialog = new RelayCommand(obj =>
        {
            AddPlaceWindow addPlaceWindow = new();
            _ = addPlaceWindow.ShowDialog();
        });

        AddWorkerDialog = new RelayCommand(obj =>
        {
            AddWorkerWindow addWorkerWindow = new() { DataContext = AddWorkerWindowViewModel };
            _ = addWorkerWindow.ShowDialog();
        });

        RemovePlaceDialog = new RelayCommand(obj =>
        {
            RemovePlaceWindow removePlaceWindow = new();
            _ = removePlaceWindow.ShowDialog();
        });

        RemoveWorkerDialog = new RelayCommand(obj =>
        {
            RemoveWorkerWindow removeWorkerWindow = new() { DataContext = RemoveWorkerWindowViewModel };
            _ = removeWorkerWindow.ShowDialog();
        });

        _workerModels ??= new ObservableCollection<IWorkerModel>();
    }

    public IWorkerModel? SelectedWorker
    {
        get => _selectedWorker;
        set
        {
            _selectedWorker = value;
            OnPropertyChanged(nameof(SelectedWorker));
        }
    }

    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
    public ICommand RemovePlaceDialog { get; }
    public ICommand RemoveWorkerDialog { get; }

    private BaseViewModel AddWorkerWindowViewModel => new AddWorkerWindowViewModes(WorkerModels);
    private BaseViewModel RemoveWorkerWindowViewModel => new RemoveWorkerWindowViewModel(WorkerModels, SelectedWorker);

    public IList<IWorkerModel> WorkerModels
    {
        get => _workerModels;
        set
        {
            _workerModels = value;
            OnPropertyChanged(nameof(WorkerModels));
        }
    }
}