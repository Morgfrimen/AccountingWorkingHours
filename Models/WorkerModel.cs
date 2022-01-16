using System.Collections.ObjectModel;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class WorkerModel : IWorkerModel
{
    public WorkerModel()
    {
        Places = new ObservableCollection<PlaceModel>();
        WorkerInfos = new ObservableCollection<WorkerInfo>();
    }

    public WorkerModel(string? name, string? imageSource = null) : this()
    {
        Name = name;
        ImageSource = imageSource;
    }

    public string? Name { get; set; }
    public string? ImageSource { get; set; }
    public ObservableCollection<PlaceModel>? Places { get; set; }
    public ObservableCollection<WorkerInfo>? WorkerInfos { get; set; }
}