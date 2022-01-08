using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.ViewModels.Abstracts;
using AccountingWorkingHours.Views;

namespace AccountingWorkingHours.ViewModels;

public sealed class MainWindowViewModel : BaseViewModel, IMainWindowViewModel 
{
    private readonly ICommand _addPlaceDialog;

    public MainWindowViewModel(AddPlaceWindow addPlaceWindow)
    {
        _addPlaceDialog = new RelayCommand((obg)=>{ addPlaceWindow.Show();});
    }

    public ICommand AddPlaceDialog => _addPlaceDialog;
}