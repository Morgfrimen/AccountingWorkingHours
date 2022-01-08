using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;

namespace AccountingWorkingHours.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel, IMainWindowViewModel 
{
    public MainWindowViewModel(AddPlaceWindow addPlaceWindow)
    {
        AddPlaceDialog = new RelayCommand((obj)=>{ addPlaceWindow.ShowDialog();});
    }

    public ICommand AddPlaceDialog { get; }
}