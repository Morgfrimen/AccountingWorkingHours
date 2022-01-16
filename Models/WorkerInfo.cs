using System;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class WorkerInfo : IWorkerInfo
{
    public WorkerInfo() => Place = new PlaceModel();

    public DateTime Date { get; set; }
    public bool IsPrepaid { get; set; }
    public PlaceModel? Place { get; set; }
}