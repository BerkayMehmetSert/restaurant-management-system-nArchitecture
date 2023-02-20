using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Project.Application.Features.Payments.Models;
using Project.Application.Features.Payments.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Payments.Queries.GetAllPayment
{
    public class GetAllPaymentQuery : IRequest<PaymentListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllPaymentQueryHandler : IRequestHandler<GetAllPaymentQuery, PaymentListModel>
        {
            private readonly IPaymentRepository _paymentRepository;
            private readonly IMapper _mapper;
            private readonly PaymentBusinessRules _paymentBusinessRules;

            public GetAllPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper,
                PaymentBusinessRules paymentBusinessRules)
            {
                _paymentRepository = paymentRepository;
                _mapper = mapper;
                _paymentBusinessRules = paymentBusinessRules;
            }

            public async Task<PaymentListModel> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
            {
                var payments = await _paymentRepository.GetListAsync(
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                    );

                _paymentBusinessRules.CheckIfPaymentListEmpty(payments);
                var result = _mapper.Map<PaymentListModel>(payments);

                return result;
            }
        }
    }
}
