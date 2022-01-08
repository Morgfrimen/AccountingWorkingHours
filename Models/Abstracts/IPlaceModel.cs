using System;
using System.Collections.Generic;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IPlaceModel
{
    public string NamePlace { get; set; }
    public DateOnly Date { get; set; }
    public string? ImageSource { get; set; } //TODO: Затычка

    public IList<IWorkerModel>? Workers { get; set; }
}