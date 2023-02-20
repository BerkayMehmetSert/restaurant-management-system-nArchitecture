using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.TransactionReports.Commands.CreateTransactionReport;
using Project.Application.Features.TransactionReports.Commands.DeleteTransactionReport;
using Project.Application.Features.TransactionReports.Dto;
using Project.Application.Features.TransactionReports.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.TransactionReports.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionReport, CreateTransactionReportCommand>().ReverseMap();
            CreateMap<TransactionReport, CreatedTransactionReportDto>().ReverseMap();
            CreateMap<TransactionReport, DeleteTransactionReportCommand>().ReverseMap();
            CreateMap<TransactionReport, DeletedTransactionReportDto>().ReverseMap();
            CreateMap<TransactionReport, TransactionReportDto>().ReverseMap();
            CreateMap<TransactionReport, TransactionReportListDto>().ReverseMap();
            CreateMap<IPaginate<TransactionReport>, TransactionReportListModel>().ReverseMap();
        }
    }
}
