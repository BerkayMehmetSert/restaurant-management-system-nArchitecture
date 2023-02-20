using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.Customers.Models;
using Project.Application.Features.Customers.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : IRequest<CustomerListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, CustomerListModel>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly  IMapper _mapper;
            private readonly  CustomerBusinessRules _customerBusinessRules;

            public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, 
                IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<CustomerListModel> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetListAsync(
                    include: 
                    x=>x.Include(y=>y.OrderDetails)
                        .Include(y=>y.Payments)
                        .Include(y=>y.TransactionReports),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                );

                _customerBusinessRules.CheckIfCustomerListEmpty(customers);

                var result = _mapper.Map<CustomerListModel>(customers);

                return result;
            }
        }
    }
}
