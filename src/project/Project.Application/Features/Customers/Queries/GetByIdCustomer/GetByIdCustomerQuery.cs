using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Customers.Dto;
using Project.Application.Features.Customers.Rules;

namespace Project.Application.Features.Customers.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }

        public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerDto>
        {
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdCustomerQueryHandler(IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerBusinessRules.CheckIfCustomerExists(request.Id);

                var result = _mapper.Map<CustomerDto>(customer);

                return result;
            }
        }
    }
}
