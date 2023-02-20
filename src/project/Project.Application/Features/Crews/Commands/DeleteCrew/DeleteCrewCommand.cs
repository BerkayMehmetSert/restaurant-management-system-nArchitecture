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

namespace Project.Application.Features.Crews.Commands.DeleteCrew
{
    public class DeleteCrewCommand : IRequest<DeletedCrewDto>
    {
        public int Id { get; set; }

        public class DeleteCrewCommandHandler : IRequestHandler<DeleteCrewCommand, DeletedCrewDto>
        {
            private readonly ICrewRepository _crewRepository;
            private readonly IMapper _mapper;
            private readonly CrewBusinessRules _crewBusinessRules;

            public DeleteCrewCommandHandler(ICrewRepository crewRepository, IMapper mapper,
                CrewBusinessRules crewBusinessRules)
            {
                _crewRepository = crewRepository;
                _mapper = mapper;
                _crewBusinessRules = crewBusinessRules;
            }

            public async Task<DeletedCrewDto> Handle(DeleteCrewCommand request, CancellationToken cancellationToken)
            {
                var crew = await _crewBusinessRules.CheckIfCrewExistById(request.Id);

                var deleted = await _crewRepository.DeleteAsync(crew);

                var result = _mapper.Map<DeletedCrewDto>(deleted);

                return result;
            }
        }
    }
}
