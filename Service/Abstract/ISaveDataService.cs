using System.Collections.Generic;
using AccountingWorkingHours.Models;

namespace AccountingWorkingHours.Service.Abstract;

public interface ISaveDataService
{
    void SaveWorkers(IList<WorkerModel> workers);

    IEnumerable<WorkerModel>? GetWorkers();
}