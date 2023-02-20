using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.CrewService
{
    public class CrewManager : ICrewService
    {
        private readonly ICrewRepository _crewRepository;

        public CrewManager(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        public async Task<Crew> GetCrewById(int id)
        {
            var crew = await _crewRepository.GetAsync(x => x.Id == id);

            return crew!;
        }
    }
}
