using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AccountingWorkingHours.Dto;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.Service.Abstract;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AccountingWorkingHours.Service;

public sealed class SaveDataService : ISaveDataService
{
    private readonly ILogger<SaveDataService> _logger;
    private readonly IMapper _mapper;

    private readonly string _pathFile = Path.Combine(Environment.CurrentDirectory, "Data", "worker.xml");

    public SaveDataService(IMapper mapper, ILogger<SaveDataService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public void SaveWorkers(IList<IWorkerModel> workers)
    {
        try
        {
            var workersDto = _mapper.Map<IList<WorkerDto>>(workers);
            var xmlSerializer = new XmlSerializer(typeof(WorkerDto[]));

            using var fs = new FileStream(_pathFile, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs, workersDto.ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка в сохранении XML => Worker");
        }
    }

    public IEnumerable<IWorkerModel>? GetWorkers()
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(WorkerDto[]));
            using var fs = new FileStream(_pathFile, FileMode.OpenOrCreate);
            var workersDto = xmlSerializer.Deserialize(fs) as WorkerDto[];
            var workers = _mapper.Map<IList<WorkerModel>>(workersDto).Cast<IWorkerModel>();
            return workers;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка в получении XML => Worker");
            return default;
        }
    }
}