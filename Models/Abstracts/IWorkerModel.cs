using System.Collections.ObjectModel;

namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerModel
{
    //TODO: Пока не понятно в каком ввиде будет работа с изображениями, поэтому затычка с типом String
    public string? ImageSource { get; set; }
    public string? Name { get; set; }
    public ObservableCollection<PlaceModel>? Places { get; set; }
    public ObservableCollection<WorkerInfo>? WorkerInfos { get; set; }
}