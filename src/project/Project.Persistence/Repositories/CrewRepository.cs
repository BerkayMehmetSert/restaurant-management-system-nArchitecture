using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories
{
    public class CrewRepository : EfRepositoryBase<Crew, BaseDbContext>, ICrewRepository
    {
        public CrewRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
