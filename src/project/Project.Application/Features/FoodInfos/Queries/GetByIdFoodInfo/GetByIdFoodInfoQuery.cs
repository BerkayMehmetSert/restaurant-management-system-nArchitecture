using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.FoodInfos.Dto;
using Project.Application.Features.FoodInfos.Rules;

namespace Project.Application.Features.FoodInfos.Queries.GetByIdFoodInfo
{
    public class GetByIdFoodInfoQuery : IRequest<FoodInfoDto>
    {
        public int Id { get; set; }

        public class GetByIdFoodInfoQueryHandler : IRequestHandler<GetByIdFoodInfoQuery, FoodInfoDto>
        {
            private readonly FoodInfoBusinessRules _foodInfoBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdFoodInfoQueryHandler(FoodInfoBusinessRules foodInfoBusinessRules, IMapper mapper)
            {
                _foodInfoBusinessRules = foodInfoBusinessRules;
                _mapper = mapper;
            }

            public async Task<FoodInfoDto> Handle(GetByIdFoodInfoQuery request, CancellationToken cancellationToken)
            {
                var food = await _foodInfoBusinessRules.CheckFoodInfoExists(request.Id);

                var result = _mapper.Map<FoodInfoDto>(food);

                return result;
            }
        }
    }
}
