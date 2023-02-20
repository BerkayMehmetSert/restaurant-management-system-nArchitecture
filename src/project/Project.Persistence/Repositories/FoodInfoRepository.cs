using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class FoodInfoRepository : EfRepositoryBase<FoodInfo, BaseDbContext>, IFoodInfoRepository
{
    public FoodInfoRepository(BaseDbContext context) : base(context)
    {
    }
}