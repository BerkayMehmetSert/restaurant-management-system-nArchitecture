using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.Crews.Models;
using Project.Application.Features.Crews.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Crews.Queries.GetAllCrew
{
    public class GetAllCrewQuery : IRequest<CrewListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCrewQueryHandler: IRequestHandler<GetAllCrewQuery, CrewListModel>
        {
            private readonly ICrewRepository _crewRepository;
            private readonly IMapper _mapper;
            private readonly CrewBusinessRules _crewBusinessRules;

            public GetAllCrewQueryHandler(ICrewRepository crewRepository, IMapper mapper, 
                CrewBusinessRules crewBusinessRules)
            {
                _crewRepository = crewRepository;
                _mapper = mapper;
                _crewBusinessRules = crewBusinessRules;
            }

            public async Task<CrewListModel> Handle(GetAllCrewQuery request, CancellationToken cancellationToken)
            {
                var crews = await _crewRepository.GetListAsync(
                    include: 
                    x=>x.Include(y=>y.OrderDetails)
                        .Include(y=>y.TransactionReports),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                );

                _crewBusinessRules.CheckIfCrewListEmpty(crews);

                var result = _mapper.Map<CrewListModel>(crews);

                return result;
            }
        }
    }
}
