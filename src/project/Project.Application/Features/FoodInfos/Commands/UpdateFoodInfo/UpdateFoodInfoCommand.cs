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

namespace Project.Application.Features.FoodInfos.Commands.UpdateFoodInfo
{
    public class UpdateFoodInfoCommand : IRequest<UpdatedFoodInfoDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }

        public class UpdatedFoodInfoCommandHandler : IRequestHandler<UpdateFoodInfoCommand, UpdatedFoodInfoDto>
        {
            private readonly IFoodInfoRepository _foodInfoRepository;
            private readonly IMapper _mapper;
            private readonly FoodInfoBusinessRules _foodInfoBusinessRules;

            public UpdatedFoodInfoCommandHandler(IFoodInfoRepository foodInfoRepository,
                IMapper mapper, FoodInfoBusinessRules foodInfoBusinessRules)
            {
                _foodInfoRepository = foodInfoRepository;
                _mapper = mapper;
                _foodInfoBusinessRules = foodInfoBusinessRules;
            }

            public async Task<UpdatedFoodInfoDto> Handle(UpdateFoodInfoCommand request, CancellationToken cancellationToken)
            {
                var food = await _foodInfoBusinessRules.CheckFoodInfoExists(request.Id);
                food.Name = request.Name;
                food.Status = request.Status;
                food.Price = request.Price;

                var update = await _foodInfoRepository.UpdateAsync(food);

                var result = _mapper.Map<UpdatedFoodInfoDto>(update);

                return result;
            }
        }
    }
}
