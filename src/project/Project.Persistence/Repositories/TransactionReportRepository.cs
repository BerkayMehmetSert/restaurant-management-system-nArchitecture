using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class TransactionReportRepository : EfRepositoryBase<TransactionReport, BaseDbContext>,
    ITransactionReportRepository
{
    public TransactionReportRepository(BaseDbContext context) : base(context)
    {
    }
}