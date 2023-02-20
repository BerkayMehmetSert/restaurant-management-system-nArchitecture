using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.CrewService
{
    public interface ICrewService
    {
        public Task<Crew> GetCrewById(int id);
    }
}
