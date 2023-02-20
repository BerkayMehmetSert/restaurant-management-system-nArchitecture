using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class DeliveryRepository : EfRepositoryBase<Delivery, BaseDbContext>, IDeliveryRepository
{
    public DeliveryRepository(BaseDbContext context) : base(context)
    {
    }
}