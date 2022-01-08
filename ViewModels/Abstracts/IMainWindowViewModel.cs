using System.Windows.Input;

namespace AccountingWorkingHours.ViewModels.Abstracts;

public interface IMainWindowViewModel
{
    public ICommand AddPlaceDialog { get; }
}