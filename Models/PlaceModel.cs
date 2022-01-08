using System;
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

    public string NamePlace { get; }
    public DateOnly Date { get; }
    public string? ImageSource { get; }
}