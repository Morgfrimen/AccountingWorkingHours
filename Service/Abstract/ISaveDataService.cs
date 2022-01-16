using System.Collections.Generic;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Service.Abstract;

public interface ISaveDataService
{
    void SaveWorkers(IList<WorkerModel> workers);

    IEnumerable<IWorkerModel>? GetWorkers();
}