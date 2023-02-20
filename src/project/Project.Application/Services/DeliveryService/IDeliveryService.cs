using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.DeliveryService
{
    public interface IDeliveryService
    {
        public Task<Delivery> GetDeliveryById(int deliveryId);
    }
}
