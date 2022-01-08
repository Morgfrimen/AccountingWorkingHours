using System;
using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Models;

public class PlaceModel : IPlaceModel
{
    public PlaceModel(string namePlace, DateOnly date, string? imageSource = null)
    {
        NamePlace = namePlace;
        Date = date;
        ImageSource = imageSource;
    }

    public string NamePlace { get; set; }
    public DateOnly Date { get; set; }
    public string? ImageSource { get; set; }
    public IList<IWorkerModel>? Workers { get; set; }
}