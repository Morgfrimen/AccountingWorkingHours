using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;
using AccountingWorkingHours.Dto;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AccountingWorkingHours.Service;

public sealed class SaveDataService : IHostedService
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

    private void SaveWorkers(IList<IWorkerModel> workers)
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

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new System.Timers.Timer(new TimeSpan(0, 1, 30).TotalSeconds);
        _timer.Elapsed += Timer_Elapsed;
        _timer.Start();
        return Task.CompletedTask;
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e) => SaveWorkers(_mainWindowViewModel.WorkerModels);

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Stop();
        return Task.CompletedTask;
    }
}