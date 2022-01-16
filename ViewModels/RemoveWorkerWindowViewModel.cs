using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.ViewModels;

public sealed class RemoveWorkerWindowViewModel : BaseViewModel
{
    public RemoveWorkerWindowViewModel(IList<WorkerModel> workerModels, WorkerModel? worker)
    {
        var model = worker;
        WorkerModels = workerModels;
        RemoveWorkerCommand = new RelayCommand(obj =>
        {
            if (model is null || !WorkerModels.Remove(model))
            {
                _ = MessageBox.Show("Сотрудник уже был удален", "Уведомление", MessageBoxButton.OK,
                    MessageBoxImage.Warning,
                    MessageBoxResult.OK);
                return;
            }

            var window = obj as Window;
            window!.DialogResult = true;
            window.Close();
        });
    }

    public ICommand RemoveWorkerCommand { get; }
    private IList<WorkerModel> WorkerModels { get; }
}