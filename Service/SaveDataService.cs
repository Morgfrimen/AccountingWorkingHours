using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AccountingWorkingHours.Dto;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.Service.Abstract;
using AccountingWorkingHours.ViewModels.Abstracts;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AccountingWorkingHours.Service;

public sealed class SaveDataService : ISaveDataService
{
    private readonly IMapper _mapper;
    private readonly ILogger<SaveDataService> _logger;
    private readonly IMainWindowViewModel _mainWindowViewModel;

    private System.Timers.Timer _timer;

    public SaveDataService(IMapper mapper, ILogger<SaveDataService> logger, IMainWindowViewModel mainWindowViewModel)
    {
        _mapper = mapper;
        _logger = logger;
        _mainWindowViewModel = mainWindowViewModel;
    }

    public void SaveWorkers(IList<IWorkerModel> workers)
    {
        try
        {
            var workersDto = _mapper.Map<IList<WorkerDto>>(workers);
            var xmlSerializer = new XmlSerializer(typeof(WorkerDto[]));

            using var fs = new FileStream(Path.Combine("Data", "worker.xml"), FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs, workersDto.ToArray());
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Ошибка в сохранении XML => Worker");
        }
    }
}