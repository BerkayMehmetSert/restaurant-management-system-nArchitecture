using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Payments.Dto;
using Project.Application.Features.Payments.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatedPaymentDto>
    {
        public int CustomerId { get; set; }
        public int OrderDetailId { get; set; }
        public int DeliveryId { get; set; }
        public double Amount { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatedPaymentDto>
        {
            private readonly IPaymentRepository _paymentRepository;
            private readonly IMapper _mapper;
            private readonly PaymentBusinessRules _paymentBusinessRules;


            public CreatePaymentCommandHandler(IPaymentRepository paymentRepository,
                IMapper mapper, PaymentBusinessRules paymentBusinessRules)
            {
                _paymentRepository = paymentRepository;
                _mapper = mapper;
                _paymentBusinessRules = paymentBusinessRules;
            }

            public async Task<CreatedPaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                var requestToEntity = _mapper.Map<Payment>(request);

                var create = await _paymentRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedPaymentDto>(create);

                return result;
            }
        }
    }
}
