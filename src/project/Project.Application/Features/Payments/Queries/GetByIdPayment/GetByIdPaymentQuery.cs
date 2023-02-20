using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Payments.Dto;
using Project.Application.Features.Payments.Rules;

namespace Project.Application.Features.Payments.Queries.GetByIdPayment
{
    public class GetByIdPaymentQuery : IRequest<PaymentDto>
    {
        public int Id { get; set; }

        public class GetByIdPaymentQueryHandler : IRequestHandler<GetByIdPaymentQuery, PaymentDto>
        {
            private readonly IMapper _mapper;
            private readonly PaymentBusinessRules _paymentBusinessRules;

            public GetByIdPaymentQueryHandler(IMapper mapper, PaymentBusinessRules paymentBusinessRules)
            {
                _mapper = mapper;
                _paymentBusinessRules = paymentBusinessRules;
            }

            public async Task<PaymentDto> Handle(GetByIdPaymentQuery request, CancellationToken cancellationToken)
            {
                var payment = await _paymentBusinessRules.CheckPaymentExist(request.Id);

                var result = _mapper.Map<PaymentDto>(payment);

                return result;
            }
        }
    }
}
