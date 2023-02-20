using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.FoodInfos.Dto
{
    public class CreatedFoodInfoDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
    }
}
