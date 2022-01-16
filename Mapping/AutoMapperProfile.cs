using AccountingWorkingHours.Dto;
using AccountingWorkingHours.Models;
using AutoMapper;

namespace AccountingWorkingHours.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() => _ = CreateMap<WorkerDto, WorkerModel>()
            .ForMember(m => m.Places, dto => dto.Ignore())
            .ForMember(m => m.WorkerInfos, dto => dto.Ignore())

            .ReverseMap();
}