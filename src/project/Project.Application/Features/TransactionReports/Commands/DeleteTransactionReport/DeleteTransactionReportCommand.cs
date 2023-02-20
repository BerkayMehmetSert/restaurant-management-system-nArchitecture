using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.TransactionReports.Dto;
using Project.Application.Features.TransactionReports.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.TransactionReports.Commands.DeleteTransactionReport
{
    public class DeleteTransactionReportCommand : IRequest<DeletedTransactionReportDto>
    {
        public int Id { get; set; }

        public class DeletedTransactionReportCommandHandler : IRequestHandler<DeleteTransactionReportCommand, DeletedTransactionReportDto>
        {
            private readonly ITransactionReportRepository _transactionReportRepository;
            private readonly IMapper _mapper;
            private readonly TransactionReportBusinessRules _transactionReportBusinessRules;

            public DeletedTransactionReportCommandHandler(ITransactionReportRepository transactionReportRepository,
                IMapper mapper, TransactionReportBusinessRules transactionReportBusinessRules)
            {
                _transactionReportRepository = transactionReportRepository;
                _mapper = mapper;
                _transactionReportBusinessRules = transactionReportBusinessRules;
            }

            public async Task<DeletedTransactionReportDto> Handle(DeleteTransactionReportCommand request, CancellationToken cancellationToken)
            {
                var transactionReport = await _transactionReportBusinessRules.CheckIfTransactionReportExist(request.Id);

                var delete = await _transactionReportRepository.DeleteAsync(transactionReport);

                var result = _mapper.Map<DeletedTransactionReportDto>(delete);

                return result;
            }
        }
    }
}
