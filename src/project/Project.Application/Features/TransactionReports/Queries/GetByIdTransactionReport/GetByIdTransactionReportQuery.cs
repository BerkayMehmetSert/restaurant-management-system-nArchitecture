using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.TransactionReports.Dto;
using Project.Application.Features.TransactionReports.Rules;

namespace Project.Application.Features.TransactionReports.Queries.GetByIdTransactionReport
{
    public class GetByIdTransactionReportQuery : IRequest<TransactionReportDto>
    {
        public int Id { get; set; }

        public class GetByIdTransactionReportQueryHandler : IRequestHandler<GetByIdTransactionReportQuery, TransactionReportDto>
        {
            private readonly IMapper _mapper;
            private readonly TransactionReportBusinessRules _transactionReportBusinessRules;

            public GetByIdTransactionReportQueryHandler(IMapper mapper, TransactionReportBusinessRules transactionReportBusinessRules)
            {
                _mapper = mapper;
                _transactionReportBusinessRules = transactionReportBusinessRules;
            }

            public async Task<TransactionReportDto> Handle(GetByIdTransactionReportQuery request, CancellationToken cancellationToken)
            {
                var transactionReport = await _transactionReportBusinessRules.CheckIfTransactionReportExist(request.Id);

                var result = _mapper.Map<TransactionReportDto>(transactionReport);

                return result;
            }
        }
    }
}
