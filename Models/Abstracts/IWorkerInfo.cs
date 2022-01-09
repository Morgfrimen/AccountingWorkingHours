using System;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerInfo
{
    public DateOnly Date { get; set; }
    public IPlaceModel Place { get; set; }
    public bool IsPrepaid { get; set; }
}