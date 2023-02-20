using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class PaymentRepository : EfRepositoryBase<Payment, BaseDbContext>, IPaymentRepository
{
    public PaymentRepository(BaseDbContext context) : base(context)
    {
    }
}