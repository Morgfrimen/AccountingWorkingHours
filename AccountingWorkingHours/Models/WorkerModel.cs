using System.Collections.ObjectModel;

namespace AccountingWorkingHours.Models;

public sealed class WorkerModel
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

    public string? ImageSource { get; set; }

    public string? Name { get; set; }
    public ObservableCollection<PlaceModel>? Places { get; set; }
    public ObservableCollection<WorkerInfo>? WorkerInfos { get; set; }
}