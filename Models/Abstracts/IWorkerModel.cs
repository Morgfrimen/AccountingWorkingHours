using System.Collections.Generic;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerModel
{
    public string Name { get; set; }
    public string? ImageSource { get; set; } //TODO: Пока не понятно в каком ввиде будет работа с изображениями, поэтому затычка с типом String
    public IList<IPlaceModel>? Places { get; set; }
}