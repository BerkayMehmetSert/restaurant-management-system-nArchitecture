using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Crews.Dto;
using Project.Application.Features.Crews.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;


namespace Project.Application.Features.Crews.Commands.CreateCrew
{
    public class CreateCrewCommand : IRequest<CreatedCrewDto>
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public class CreateCrewCommandHandler : IRequestHandler<CreateCrewCommand, CreatedCrewDto>
        {
            private readonly ICrewRepository _crewRepository;
            private readonly IMapper _mapper;
            private readonly CrewBusinessRules _crewBusinessRules;

            public CreateCrewCommandHandler(ICrewRepository crewRepository, 
                IMapper mapper, CrewBusinessRules crewBusinessRules)
            {
                _crewRepository = crewRepository;
                _mapper = mapper;
                _crewBusinessRules = crewBusinessRules;
            }

            public async Task<CreatedCrewDto> Handle(CreateCrewCommand request, CancellationToken cancellationToken)
            {
                await _crewBusinessRules.CheckIfCrewUsernameIsUnique(request.Username);

                var requestToEntity = _mapper.Map<Crew>(request);
               
                var save = await _crewRepository.AddAsync(requestToEntity);
                
                var result = _mapper.Map<CreatedCrewDto>(save);

                return result;
            }
        }
    }
}
