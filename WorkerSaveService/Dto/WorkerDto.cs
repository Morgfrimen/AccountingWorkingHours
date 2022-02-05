namespace HostedService.Dto;

[Serializable]
public class WorkerDto
{
    public DateOnly? Date { get; set; }
    public string? ImageSource { get; set; }

    public string? Name { get; set; }

    //public WorkerInfo[] WorkerInfos { get; set; }
}