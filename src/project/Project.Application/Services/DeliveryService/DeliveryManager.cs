using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.DeliveryService
{
    public class DeliveryManager : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryManager(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<Delivery> GetDeliveryById(int deliveryId)
        {
            var delivery = await _deliveryRepository.GetAsync(x => x.Id == deliveryId);

            return delivery!;
        }
    }
}
