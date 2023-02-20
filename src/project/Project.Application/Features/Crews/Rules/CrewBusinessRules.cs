using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.Crews.Constants;
using Project.Application.Services.CrewService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Crews.Rules
{
    public class CrewBusinessRules : BaseBusinessRules
    {
        private readonly ICrewRepository _crewRepository;
        private readonly ICrewService _crewService;

        public CrewBusinessRules(ICrewRepository crewRepository, ICrewService crewService)
        {
            _crewRepository = crewRepository;
            _crewService = crewService;
        }

        public async Task CheckIfCrewUsernameIsUnique(string username)
        {
            var crew = await _crewRepository.GetAsync(x=>x.Username == username);

            if (crew != null) throw new BusinessException(CrewMessages.CrewUsernameAlreadyExists);
        }

        public async Task<Crew> CheckIfCrewExistById(int id)
        {
            var crew = await _crewService.GetCrewById(id);

            if (crew == null) throw new BusinessException(CrewMessages.CrewNotFoundById);
            return crew;
        }

        public void CheckIfCrewListEmpty(IPaginate<Crew> crews)
        {
            if(crews.Items.Count == 0) throw new BusinessException(CrewMessages.CrewListEmpty);
        }
    }
}
