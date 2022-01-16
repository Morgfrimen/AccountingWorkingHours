using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;

namespace AccountingWorkingHours.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
{
    private IList<PlaceModel> _placeModels;
    private PlaceModel? _selectedPlace;
    private WorkerModel? _selectedWorker;
    private ObservableCollection<WorkerModel> _workerModels;

    public MainWindowViewModel()
    {
        AddPlaceDialog = new RelayCommand(obj =>
        {
            AddPlaceWindow addPlaceWindow = new() { DataContext = AddPlaceWindowViewModel };
            _ = addPlaceWindow.ShowDialog();
        });

        AddWorkerDialog = new RelayCommand(obj =>
        {
            AddWorkerWindow addWorkerWindow = new() { DataContext = AddWorkerWindowViewModel };
            _ = addWorkerWindow.ShowDialog();
        });

        RemovePlaceDialog = new RelayCommand(obj =>
        {
            RemovePlaceWindow removePlaceWindow = new() { DataContext = RemovePlaceWindowViewModel };
            _ = removePlaceWindow.ShowDialog();
        });

        RemoveWorkerDialog = new RelayCommand(obj =>
        {
            RemoveWorkerWindow removeWorkerWindow = new() { DataContext = RemoveWorkerWindowViewModel };
            _ = removeWorkerWindow.ShowDialog();
        });

        _workerModels ??= new ObservableCollection<WorkerModel>();
        _placeModels ??= new ObservableCollection<PlaceModel>();
    }

    private BaseViewModel AddPlaceWindowViewModel => new AddPlaceWindowViewModes(PlaceModels);

    private BaseViewModel AddWorkerWindowViewModel => new AddWorkerWindowViewModes(Workers);
    private BaseViewModel RemovePlaceWindowViewModel => new RemovePlaceWindowViewModel(PlaceModels, SelectedPlace);
    private BaseViewModel RemoveWorkerWindowViewModel => new RemoveWorkerWindowViewModel(Workers, SelectedWorker);

    public PlaceModel? SelectedPlace
    {
        get => _selectedPlace;
        set
        {
            _selectedPlace = value;
            OnPropertyChanged(nameof(SelectedPlace));
        }
    }

    public WorkerModel? SelectedWorker
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

    public ObservableCollection<WorkerModel> Workers
    {
        get => _workerModels;
        set
        {
            _workerModels = value;
            OnPropertyChanged(nameof(Workers));
        }
    }

    public IList<PlaceModel> PlaceModels
    {
        get => _placeModels;
        set
        {
            _placeModels = value;
            OnPropertyChanged(nameof(PlaceModels));
        }
    }
}