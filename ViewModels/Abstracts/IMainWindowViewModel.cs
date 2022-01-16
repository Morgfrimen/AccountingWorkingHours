using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.ViewModels.Abstracts;

public interface IMainWindowViewModel
{
    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
    public IList<IPlaceModel> PlaceModels { get; set; }
    public ICommand RemovePlaceDialog { get; }
    public ICommand RemoveWorkerDialog { get; }
    public ObservableCollection<WorkerModel> Workers { get; set; }
}