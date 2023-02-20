using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Deliveries.Commands.CreateDelivery;
using Project.Application.Features.Deliveries.Commands.UpdateDelivery;
using Project.Application.Features.Deliveries.Dto;
using Project.Application.Features.Deliveries.Mapping;
using Project.Domain.Entities;

namespace Project.Application.Features.Deliveries.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Delivery, CreateDeliveryCommand>().ReverseMap();
            CreateMap<Delivery, CreatedDeliveryDto>().ReverseMap();
            CreateMap<Delivery, UpdateDeliveryCommand>().ReverseMap();
            CreateMap<Delivery, UpdatedDeliveryDto>().ReverseMap();
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<Delivery, DeliveryListDto>().ReverseMap();
            CreateMap<Payment, DeliveryPaymentDto>().ReverseMap();
            CreateMap<IPaginate<Delivery>, DeliveryListModel>().ReverseMap();
        }
    }
}
