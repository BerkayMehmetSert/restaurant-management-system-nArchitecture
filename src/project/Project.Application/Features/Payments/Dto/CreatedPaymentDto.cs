using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.Payments.Dto
{
    public class CreatedPaymentDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderDetailId { get; set; }
        public int DeliveryId { get; set; }
        public double Amount { get; set; }
    }
}
