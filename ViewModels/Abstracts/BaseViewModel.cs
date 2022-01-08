using System.ComponentModel;
using System.Runtime.CompilerServices;
using AccountingWorkingHours.Annotations;

namespace AccountingWorkingHours.ViewModels.Abstracts;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}