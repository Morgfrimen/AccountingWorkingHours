using System;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IPlaceModel
{
    public string NamePlace { get; }
    public DateOnly Date { get; }
    public string? ImageSource { get; } //TODO: Затычка
}