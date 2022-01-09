using System.Collections.Generic;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.ViewModels;

public sealed class AddWorkerWindowViewModes : BaseViewModel
{
    private string _name;

    public AddWorkerWindowViewModes(IList<IWorkerModel> workerModels)
    {
        WorkerModels = workerModels;
        AddWorker = new RelayCommand((obj) =>
        {
            WorkerModels.Add(new WorkerModel(Name));
            Name = string.Empty;
        });
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private IList<IWorkerModel> WorkerModels { get; }

    public ICommand AddWorker { get; }
}