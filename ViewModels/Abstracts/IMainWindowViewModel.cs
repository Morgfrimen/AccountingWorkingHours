using System.Collections.Generic;
using System.Windows.Input;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.ViewModels.Abstracts;

public interface IMainWindowViewModel
{
    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
    public ICommand RemovePlaceDialog { get; }
    public ICommand RemoveWorkerDialog { get; }
    public IList<IWorkerModel> WorkerModels { get; set; }
    public IList<IPlaceModel> PlaceModels { get; set; }
}