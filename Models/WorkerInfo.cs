using System;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class WorkerInfo : IWorkerInfo
{
    public WorkerInfo(DateOnly date, IPlaceModel place, bool isPrepaid)
    {
        Date = date;
        Place = place;
        IsPrepaid = isPrepaid;
    }

    public DateOnly Date { get; set; }
    public IPlaceModel Place { get; set; }
    public bool IsPrepaid { get; set; }
}