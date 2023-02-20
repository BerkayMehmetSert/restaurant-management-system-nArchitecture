using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.OrderDetails.Commands.CreateOrderDetail;
using Project.Application.Features.OrderDetails.Commands.DeleteOrderDetail;
using Project.Application.Features.OrderDetails.Commands.UpdateOrderDetail;
using Project.Application.Features.OrderDetails.Dto;
using Project.Application.Features.OrderDetails.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.OrderDetails.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, CreatedOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdatedOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, DeleteOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, DeletedOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailListDto>().ReverseMap();
            CreateMap<Payment, OrderDetailPaymentDto>().ReverseMap();
            CreateMap<IPaginate<OrderDetail>, OrderDetailListModel>();
        }
    }
}
