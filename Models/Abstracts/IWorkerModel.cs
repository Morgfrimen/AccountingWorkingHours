namespace AccountingWorkingHours.Models.Abstracts;

public interface IWorkerModel
{
    public string Name { get; }
    public string? ImageSource { get; } //TODO: Пока не понятно в каком ввиде будет работа с изображениями, поэтому затычка с типом String
}