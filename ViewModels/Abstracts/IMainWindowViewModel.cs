using System.Windows.Input;

namespace AccountingWorkingHours.ViewModels.Abstracts;

public interface IMainWindowViewModel
{
    public ICommand AddPlaceDialog { get; }
    public ICommand AddWorkerDialog { get; }
    public ICommand RemovePlaceDialog { get; }
    public ICommand RemoveWorkerDialog { get; }
}