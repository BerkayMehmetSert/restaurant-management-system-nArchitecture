using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories;

public class MenuRepository : EfRepositoryBase<Menu, BaseDbContext>, IMenuRepository
{
    public MenuRepository(BaseDbContext context) : base(context)
    {
    }
}