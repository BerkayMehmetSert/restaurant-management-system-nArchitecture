using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.Repositories
{
    public interface ICrewRepository : IAsyncRepository<Crew>
    {
    }
}
