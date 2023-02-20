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

namespace Project.Application.Features.Crews.Queries.GetByIdCrew
{
    public class GetByIdCrewQuery : IRequest<CrewDto>
    {
        public int Id { get; set; }

        public class GetByIdCrewQueryHandler : IRequestHandler<GetByIdCrewQuery, CrewDto>
        {
            private readonly ICrewRepository _crewRepository;
            private readonly IMapper _mapper;
            private readonly CrewBusinessRules _crewBusinessRules;

            public GetByIdCrewQueryHandler(ICrewRepository crewRepository, IMapper mapper, 
                CrewBusinessRules crewBusinessRules)
            {
                _crewRepository = crewRepository;
                _mapper = mapper;
                _crewBusinessRules = crewBusinessRules;
            }

            public async Task<CrewDto> Handle(GetByIdCrewQuery request, CancellationToken cancellationToken)
            {
                var crew = await _crewBusinessRules.CheckIfCrewExistById(request.Id);

                var result = _mapper.Map<CrewDto>(crew);

                return result;
            }
        }
    }
}
