using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.Deliveries.Dto
{
    public class CreatedDeliveryDto : IDto
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
    }
}
