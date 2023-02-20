using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Crews.Commands.CreateCrew;
using Project.Application.Features.Crews.Commands.DeleteCrew;
using Project.Application.Features.Crews.Commands.UpdateCrew;
using Project.Application.Features.Crews.Dto;
using Project.Application.Features.Crews.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.Crews.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crew, CreateCrewCommand>().ReverseMap();
            CreateMap<Crew, CreatedCrewDto>().ReverseMap();
            CreateMap<Crew, UpdateCrewCommand>().ReverseMap();
            CreateMap<Crew, UpdatedCrewDto>().ReverseMap();
            CreateMap<Crew, DeleteCrewCommand>().ReverseMap();
            CreateMap<Crew, DeletedCrewDto>().ReverseMap();
            CreateMap<Crew, CrewDto>().ReverseMap();
            CreateMap<Crew, CrewListDto>().ReverseMap();
            CreateMap<TransactionReport, CrewTransactionReportDto>().ReverseMap();
            CreateMap<OrderDetail, CrewOrderDetailDto>().ReverseMap();
            CreateMap<IPaginate<Crew>, CrewListModel>().ReverseMap();
        }
    }
}
