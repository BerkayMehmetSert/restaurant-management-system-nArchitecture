using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.OrderDetails.Dto
{
    public class CreatedOrderDetailDto : IDto
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public int CustomerId { get; set; }
        public int FoodInfoId { get; set; }
        public string Status { get; set; }
    }
}
