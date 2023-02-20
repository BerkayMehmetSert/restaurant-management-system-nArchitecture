using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Customers.Commands.CreateCustomer;
using Project.Application.Features.Customers.Commands.DeleteCustomer;
using Project.Application.Features.Customers.Commands.UpdateCustomer;
using Project.Application.Features.Customers.Dto;
using Project.Application.Features.Customers.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.Customers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreatedCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdatedCustomerDto>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeletedCustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<OrderDetail, CustomerOrderDetailDto>().ReverseMap();
            CreateMap<Payment, CustomerPaymentDto>().ReverseMap();
            CreateMap<TransactionReport, CustomerTransactionReportDto>().ReverseMap();
            CreateMap<IPaginate<Customer>, CustomerListModel>().ReverseMap();
        }
    }
}
