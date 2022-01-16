using System;
using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public sealed class PlaceModel : IPlaceModel
{
    public PlaceModel(string namePlace, string? imageSource = null)
    {
        NamePlace = namePlace;
        ImageSource = imageSource;
    }

    public string NamePlace { get; set; }
    public DateOnly Date { get; set; }
    public string? ImageSource { get; set; }
    public IList<IWorkerModel>? Workers { get; set; }
}