using System;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerInfo
{
    public DateTime Date { get; set; }
    public bool IsPrepaid { get; set; }
    public PlaceModel? Place { get; set; }
}