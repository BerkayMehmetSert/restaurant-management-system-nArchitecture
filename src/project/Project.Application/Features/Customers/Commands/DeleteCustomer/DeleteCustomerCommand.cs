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

namespace Project.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeletedCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IMapper _mapper;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
                CustomerBusinessRules customerBusinessRules, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _customerBusinessRules = customerBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeletedCustomerDto> Handle(DeleteCustomerCommand request,
                CancellationToken cancellationToken)
            {
                var customer = await _customerBusinessRules.CheckIfCustomerExists(request.Id);

                var delete = await _customerRepository.DeleteAsync(customer);

                var result = _mapper.Map<DeletedCustomerDto>(delete);

                return result;
            }
        }
    }
}
