using System;

namespace AccountingWorkingHours.Dto;

[Serializable]
public class WorkerDto
{
    /// <summary>
    ///     Для сериализации
    /// </summary>
#pragma warning disable CS8618
    public WorkerDto()
    {
    }
#pragma warning restore CS8618
    public DateOnly? Date { get; set; }
    public string? ImageSource { get; set; }

    public string? Name { get; set; }

    //public WorkerInfo[] WorkerInfos { get; set; }
}