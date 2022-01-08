using System;
using System.Windows.Input;

namespace AccountingWorkingHours.Commands;

public sealed class RelayCommand : ICommand
{

    private readonly Action<object?> _execute;
    private readonly Func<object?,bool>? _canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute is null || _canExecute.Invoke(parameter);
    }

    public void Execute(object? parameter)
    {
       _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}