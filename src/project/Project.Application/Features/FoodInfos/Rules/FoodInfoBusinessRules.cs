using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.FoodInfos.Constants;
using Project.Application.Services.FoodInfoService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.FoodInfos.Rules
{
    public class FoodInfoBusinessRules : BaseBusinessRules
    {
        private readonly IFoodInfoRepository _foodInfoRepository;
        private readonly  IFoodInfoService _foodInfoService;

        public FoodInfoBusinessRules(IFoodInfoRepository foodInfoRepository, IFoodInfoService foodInfoService)
        {
            _foodInfoRepository = foodInfoRepository;
            _foodInfoService = foodInfoService;
        }

        public async Task<FoodInfo> CheckFoodInfoExists(int id)
        {
            var foodInfo = await _foodInfoService.GetFoodInfoById(id);
            if (foodInfo == null) throw new BusinessException(FoodInfoMessage.FoodNotFoundById);

            return foodInfo;
        }

        public async Task CheckFoodInfoNameExists(string name)
        {
            var foodInfo = await _foodInfoRepository.GetAsync(x => x.Name == name);
            if (foodInfo != null) throw new BusinessException(FoodInfoMessage.FoodNameAlreadyExists);
        }

        public void CheckIfFoodInfoListEmpty(IPaginate<FoodInfo> foods)
        {
            if (foods.Items.Count == 0) throw new BusinessException(FoodInfoMessage.FoodInfoListEmpty);
        }
    }
}
