using System;
using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class WorkerModel : IWorkerModel, IWorkerInfo
{
    public WorkerModel(string name, string? imageSource = null)
    {
        Name = name;
        ImageSource = imageSource;
    }

    public DateOnly Date { get; set; }
    public IPlaceModel Place { get; set; }
    public bool IsPrepaid { get; set; }

    public string Name { get; set; }
    public string? ImageSource { get; set; }
    public IList<IPlaceModel>? Places { get; set; }
    public IList<IWorkerInfo>? WorkerInfos { get; set; }
}