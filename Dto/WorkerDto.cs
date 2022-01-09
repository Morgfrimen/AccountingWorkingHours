using System.Collections.Generic;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Dto;

public class WorkerDto
{
    public WorkerDto(IList<IWorkerModel> workerModels, string name)
    {
        WorkerModels = workerModels;
        Worker = new WorkerModel(name);
    }

    public IList<IWorkerModel> WorkerModels { get; }
    public IWorkerModel Worker { get; }
}