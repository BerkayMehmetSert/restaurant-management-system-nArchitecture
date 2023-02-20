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

namespace Project.Application.Features.Crews.Commands.UpdateCrew
{
    public class UpdateCrewCommand : IRequest<UpdatedCrewDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public class UpdateCrewCommandHandler : IRequestHandler<UpdateCrewCommand, UpdatedCrewDto>
        {
            private readonly ICrewRepository _crewRepository;
            private readonly IMapper _mapper;
            private readonly CrewBusinessRules _crewBusinessRules;

            public UpdateCrewCommandHandler(ICrewRepository crewRepository, 
                IMapper mapper, CrewBusinessRules crewBusinessRules)
            {
                _crewRepository = crewRepository;
                _mapper = mapper;
                _crewBusinessRules = crewBusinessRules;
            }

            public async Task<UpdatedCrewDto> Handle(UpdateCrewCommand request, CancellationToken cancellationToken)
            {
                var crew = await _crewBusinessRules.CheckIfCrewExistById(request.Id);

                crew.Name = request.Name;
                crew.Contact = request.Contact;
                crew.Address = request.Address;
                crew.Username = request.Username;
                crew.Password = request.Password;

                var update = await _crewRepository.UpdateAsync(crew);
                var result = _mapper.Map<UpdatedCrewDto>(update);

                return result;
            }
        }
    }
}
