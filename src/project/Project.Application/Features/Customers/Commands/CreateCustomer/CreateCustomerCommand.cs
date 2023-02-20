using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Customers.Dto;
using Project.Application.Features.Customers.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreatedCustomerDto>
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<CreatedCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _customerBusinessRules.CheckIfCustomerUsernameExists(request.Username);

                var requestToEntity = _mapper.Map<Customer>(request);
                
                var customer = await _customerRepository.AddAsync(requestToEntity);
               
                var result = _mapper.Map<CreatedCustomerDto>(customer);
                
                return result;

            }
        }
    }
}
