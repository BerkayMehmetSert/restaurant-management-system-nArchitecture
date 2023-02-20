using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.TransactionReports.Constants;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.TransactionReports.Rules
{
    public class TransactionReportBusinessRules : BaseBusinessRules
    {
        private readonly ITransactionReportRepository _transactionReportRepository;

        public TransactionReportBusinessRules(ITransactionReportRepository transactionReportRepository)
        {
            _transactionReportRepository = transactionReportRepository;
        }

        public async Task<TransactionReport> CheckIfTransactionReportExist(int id)
        {
            var transactionReport = await _transactionReportRepository.GetAsync(x => x.Id == id);
            if (transactionReport == null)
            {
                throw new BusinessException(TransactionReportMessages.TransactionReportNotFound);
            }

            return transactionReport;
        }

        public void CheckIfTransactionReportListEmpty(IPaginate<TransactionReport> transactionReports)
        {
            if (transactionReports.Items.Count == 0)
            {
                throw new BusinessException(TransactionReportMessages.TransactionReportListEmpty);
            }
        }
    }
}
