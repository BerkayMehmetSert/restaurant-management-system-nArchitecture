using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.FoodInfoService
{
    public interface IFoodInfoService
    {
        public Task<FoodInfo> GetFoodInfoById (int id);
    }
}
