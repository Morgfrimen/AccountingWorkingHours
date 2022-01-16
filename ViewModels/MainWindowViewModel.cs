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
    private IList<IPlaceModel> _placeModels;
    private IPlaceModel? _selectedPlace;

    public MainWindowViewModel()
    {
        AddPlaceDialog = new RelayCommand(obj =>
        {
            AddPlaceWindow addPlaceWindow = new() { DataContext = AddPlaceWindowViewModel};
            _ = addPlaceWindow.ShowDialog();
        });

        AddWorkerDialog = new RelayCommand(obj =>
        {
            AddWorkerWindow addWorkerWindow = new() { DataContext = AddWorkerWindowViewModel };
            _ = addWorkerWindow.ShowDialog();
        });

        RemovePlaceDialog = new RelayCommand(obj =>
        {
            RemovePlaceWindow removePlaceWindow = new() { DataContext = RemovePlaceWindowViewModel};
            _ = removePlaceWindow.ShowDialog();
        });

        RemoveWorkerDialog = new RelayCommand(obj =>
        {
            RemoveWorkerWindow removeWorkerWindow = new() { DataContext = RemoveWorkerWindowViewModel };
            _ = removeWorkerWindow.ShowDialog();
        });

        _workerModels ??= new ObservableCollection<IWorkerModel>();
        _placeModels ??= new ObservableCollection<IPlaceModel>();
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

    private BaseViewModel AddPlaceWindowViewModel => new AddPlaceWindowViewModes(PlaceModels);
    private BaseViewModel RemovePlaceWindowViewModel => new RemovePlaceWindowViewModel(PlaceModels, SelectedPlace);
    public IList<IWorkerModel> WorkerModels
    {
        get => _workerModels;
        set
        {
            _workerModels = value;
            OnPropertyChanged(nameof(WorkerModels));
        }
    }

    public IList<IPlaceModel> PlaceModels
    {
        get => _placeModels;
        set
        {
            _placeModels = value;
            OnPropertyChanged(nameof(PlaceModels));
        }
    }

    public IPlaceModel? SelectedPlace
    {
        get => _selectedPlace;
        set
        {
            _selectedPlace = value;
            OnPropertyChanged(nameof(SelectedPlace));
        }
    }
}