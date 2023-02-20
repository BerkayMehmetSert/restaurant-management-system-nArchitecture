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

namespace Project.Application.Features.FoodInfos.Commands.DeleteFoodInfo
{
    public class DeleteFoodInfoCommand : IRequest<DeletedFoodInfoDto>
    {
        public int Id { get; set; }

        public class DeleteFoodInfoCommandHandler : IRequestHandler<DeleteFoodInfoCommand, DeletedFoodInfoDto>
        {
            private readonly IFoodInfoRepository _foodInfoRepository;
            private readonly IMapper _mapper;
            private readonly FoodInfoBusinessRules _foodInfoBusinessRules;

            public DeleteFoodInfoCommandHandler(IFoodInfoRepository foodInfoRepository,
                IMapper mapper, FoodInfoBusinessRules foodInfoBusinessRules)
            {
                _foodInfoRepository = foodInfoRepository;
                _mapper = mapper;
                _foodInfoBusinessRules = foodInfoBusinessRules;
            }

            public async Task<DeletedFoodInfoDto> Handle(DeleteFoodInfoCommand request, CancellationToken cancellationToken)
            {
                var food = await _foodInfoBusinessRules.CheckFoodInfoExists(request.Id);

                var delete = await _foodInfoRepository.DeleteAsync(food);

                var result = _mapper.Map<DeletedFoodInfoDto>(delete);

                return result;
            }
        }
    }
}
