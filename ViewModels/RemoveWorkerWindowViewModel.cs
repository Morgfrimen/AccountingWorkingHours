using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.ViewModels;

public sealed class RemoveWorkerWindowViewModel : BaseViewModel
{
    private IList<IWorkerModel> WorkerModels { get; }

    public RemoveWorkerWindowViewModel(IList<IWorkerModel> workerModels, IWorkerModel? worker)
    {
        var model = worker;
        WorkerModels = workerModels;
        RemoveWorkerCommand = new RelayCommand((obj) =>
        {
            if (model is null || !WorkerModels.Remove(model))
            {
                MessageBox.Show("Сотрудник уже был удален", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning,
                    MessageBoxResult.OK);
                return;
            }

            var window = obj as Window;
            window!.DialogResult = true;
            window.Close();
        });
    }

    public ICommand RemoveWorkerCommand { get; }
}