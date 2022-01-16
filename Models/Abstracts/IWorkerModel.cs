using System.Collections.Generic;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerModel
{
    //TODO: Пока не понятно в каком ввиде будет работа с изображениями, поэтому затычка с типом String
    public string? ImageSource { get; set; }
    public string? Name { get; set; }
    public IList<IPlaceModel>? Places { get; set; }
    public IList<IWorkerInfo>? WorkerInfos { get; set; }
}