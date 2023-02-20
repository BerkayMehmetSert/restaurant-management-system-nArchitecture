using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Payments.Commands.CreatePayment;
using Project.Application.Features.Payments.Dto;
using Project.Application.Features.Payments.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.Payments.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Payment, CreatePaymentCommand>().ReverseMap();
            CreateMap<Payment, CreatedPaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentListDto>().ReverseMap();
            CreateMap<IPaginate<Payment>, PaymentListModel>().ReverseMap();
        }
    }
}
