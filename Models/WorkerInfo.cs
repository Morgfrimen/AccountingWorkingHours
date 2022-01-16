using System;

namespace AccountingWorkingHours.Models;

public sealed class WorkerInfo
{
    public WorkerInfo() => Place = new PlaceModel();

    public DateTime Date { get; set; }
    public bool IsPrepaid { get; set; }
    public PlaceModel? Place { get; set; }
}