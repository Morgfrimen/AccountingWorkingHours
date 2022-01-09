using System;

namespace AccountingWorkingHours.Dto;

[Serializable]
public class WorkerDto
{
    /// <summary>
    /// Для сериализации
    /// </summary>
    public WorkerDto() { }

    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public string ImageSource { get; set; }
}