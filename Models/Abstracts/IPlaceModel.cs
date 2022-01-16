using System;
using System.Collections.Generic;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IPlaceModel
{
    public DateOnly Date { get; set; }
    public string? ImageSource { get; set; } //TODO: Затычка
    public string? NamePlace { get; set; }

    public IList<IWorkerModel>? Workers { get; set; }
}