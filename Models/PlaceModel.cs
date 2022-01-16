using System;
using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class PlaceModel : IPlaceModel
{
    public PlaceModel() => Workers = new List<IWorkerModel>();
    public PlaceModel(string? namePlace, string? imageSource = null) : this()
    {
        NamePlace = namePlace;
        ImageSource = imageSource;
    }

    public string? NamePlace { get; set; }
    public DateTime Date { get; set; }
    public string? ImageSource { get; set; }
    public IList<IWorkerModel>? Workers { get; set; }
}