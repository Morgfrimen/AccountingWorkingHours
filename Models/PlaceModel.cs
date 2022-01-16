using System;
using System.Collections.Generic;

namespace AccountingWorkingHours.Models;

public sealed class PlaceModel
{
    public PlaceModel() => Workers = new List<WorkerModel>();

    public PlaceModel(string? namePlace, string? imageSource = null) : this()
    {
        NamePlace = namePlace;
        ImageSource = imageSource;
    }

    public DateTime Date { get; set; }
    public string? ImageSource { get; set; }

    public string? NamePlace { get; set; }
    public IList<WorkerModel>? Workers { get; set; }
}