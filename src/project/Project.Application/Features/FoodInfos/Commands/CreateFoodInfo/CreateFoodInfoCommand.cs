using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.FoodInfos.Dto;
using Project.Application.Features.FoodInfos.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.FoodInfos.Commands.CreateFoodInfo
{
    public class CreateFoodInfoCommand : IRequest<CreatedFoodInfoDto>
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }

        public class CreateFoodInfoCommandHandler : IRequestHandler<CreateFoodInfoCommand, CreatedFoodInfoDto>
        {
            private readonly IFoodInfoRepository _foodInfoRepository;
            private readonly IMapper _mapper;
            private readonly FoodInfoBusinessRules _foodInfoBusinessRules;

            public CreateFoodInfoCommandHandler(IFoodInfoRepository foodInfoRepository,
                IMapper mapper, FoodInfoBusinessRules foodInfoBusinessRules)
            {
                _foodInfoRepository = foodInfoRepository;
                _mapper = mapper;
                _foodInfoBusinessRules = foodInfoBusinessRules;
            }

            public async Task<CreatedFoodInfoDto> Handle(CreateFoodInfoCommand request,
                CancellationToken cancellationToken)
            {
                await _foodInfoBusinessRules.CheckFoodInfoNameExists(request.Name);

                var requestToEntity = _mapper.Map<FoodInfo>(request);

                var save = await _foodInfoRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedFoodInfoDto>(save);

                return result;
            }
        }
    }
}
