using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.Menus.Dto
{
    public class CreatedMenuDto : IDto
    {
        public int Id { get; set; }
        public int FoodInfoId { get; set; }
        public string Details { get; set; }
    }
}
