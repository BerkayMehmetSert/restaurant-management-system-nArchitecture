using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Project.Application.Features.TransactionReports.Models;
using Project.Application.Features.TransactionReports.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.TransactionReports.Queries.GetAllTransactionReport
{
    public class GetALlTransactionReportQuery : IRequest<TransactionReportListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllTransactionReportQueryHandler : IRequestHandler<GetALlTransactionReportQuery, TransactionReportListModel>
        {
            private readonly ITransactionReportRepository _transactionReportRepository;
            private readonly IMapper _mapper;
            private readonly TransactionReportBusinessRules _transactionReportBusinessRules;

            public GetAllTransactionReportQueryHandler(ITransactionReportRepository transactionReportRepository,
                IMapper mapper, TransactionReportBusinessRules transactionReportBusinessRules)
            {
                _transactionReportRepository = transactionReportRepository;
                _mapper = mapper;
                _transactionReportBusinessRules = transactionReportBusinessRules;
            }

            public async Task<TransactionReportListModel> Handle(GetALlTransactionReportQuery request, CancellationToken cancellationToken)
            {
                var transactionReports = await _transactionReportRepository.GetListAsync(
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                    );

                _transactionReportBusinessRules.CheckIfTransactionReportListEmpty(transactionReports);

                var result = _mapper.Map<TransactionReportListModel>(transactionReports);

                return result;
            }
        }
    }
}
