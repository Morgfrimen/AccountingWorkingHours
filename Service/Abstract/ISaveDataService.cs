using System.Collections.Generic;
using AccountingWorkingHours.Models.Abstracts;

namespace AccountingWorkingHours.Service.Abstract;

public interface ISaveDataService
{
    void SaveWorkers(IList<IWorkerModel> workers);

    IEnumerable<IWorkerModel>? GetWorkers();
}