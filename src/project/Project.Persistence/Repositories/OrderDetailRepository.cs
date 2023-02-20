using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class OrderDetailRepository : EfRepositoryBase<OrderDetail, BaseDbContext>, IOrderDetailRepository
{
    public OrderDetailRepository(BaseDbContext context) : base(context)
    {
    }
}