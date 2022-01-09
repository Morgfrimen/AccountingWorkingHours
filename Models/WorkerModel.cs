using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class WorkerModel : IWorkerModel
{
    public WorkerModel(string name, string? imageSource = null)
    {
        Name = name;
        ImageSource = imageSource;
    }

    public string Name { get; set; }
    public string? ImageSource { get; set; }
    public IList<IPlaceModel>? Places { get; set; }
    public IList<IWorkerInfo> WorkerInfos { get; set; }
}