using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.FoodInfoService
{
    public class FoodInfoManager : IFoodInfoService
    {
        private readonly IFoodInfoRepository _foodInfoRepository;

        public FoodInfoManager(IFoodInfoRepository foodInfoRepository)
        {
            _foodInfoRepository = foodInfoRepository;
        }

        public async Task<FoodInfo> GetFoodInfoById(int id)
        {
            var foodInfo = await _foodInfoRepository.GetAsync(x => x.Id == id);
            return foodInfo!;
        }
    }
}
