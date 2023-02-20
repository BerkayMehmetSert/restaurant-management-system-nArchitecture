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

namespace Project.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdatedCustomerDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, 
                IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<UpdatedCustomerDto> Handle(UpdateCustomerCommand request,
                CancellationToken cancellationToken)
            {

                var customer = await _customerBusinessRules.CheckIfCustomerExists(request.Id);

                customer.Name = request.Name;
                customer.Contact = request.Contact;
                customer.Address = request.Address;
                customer.Username = request.Username;
                customer.Password = request.Password;

                var update = await _customerRepository.UpdateAsync(customer);

                var result = _mapper.Map<UpdatedCustomerDto>(update);

                return result;
            }
        }
    }
}
