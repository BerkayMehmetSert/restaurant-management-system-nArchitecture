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
using Project.Domain.Entities;

namespace Project.Application.Features.TransactionReports.Commands.CreateTransactionReport
{
    public class CreateTransactionReportCommand : IRequest<CreatedTransactionReportDto>
    {
        public int CustomerId { get; set; }
        public int CrewId { get; set; }
        public int OrderDetailId { get; set; }

        public class CreateTransactionReportCommandHandler : IRequestHandler<CreateTransactionReportCommand, CreatedTransactionReportDto>
        {
            private readonly ITransactionReportRepository _transactionReportRepository;
            private readonly IMapper _mapper;
            private readonly TransactionReportBusinessRules _transactionReportBusinessRules;

            public CreateTransactionReportCommandHandler(ITransactionReportRepository transactionReportRepository,
                IMapper mapper, TransactionReportBusinessRules transactionReportBusinessRules)
            {
                _transactionReportRepository = transactionReportRepository;
                _mapper = mapper;
                _transactionReportBusinessRules = transactionReportBusinessRules;
            }

            public async Task<CreatedTransactionReportDto> Handle(CreateTransactionReportCommand request, CancellationToken cancellationToken)
            {
                var requestToEntity = _mapper.Map<TransactionReport>(request);

                var create = await _transactionReportRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedTransactionReportDto>(create);

                return result;
            }
        }
    }
}
