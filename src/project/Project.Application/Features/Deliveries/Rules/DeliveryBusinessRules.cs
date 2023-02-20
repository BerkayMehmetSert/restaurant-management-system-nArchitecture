using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.Deliveries.Constants;
using Project.Application.Services.DeliveryService;
using Project.Application.Services.OrderDetailService;
using Project.Domain.Entities;

namespace Project.Application.Features.Deliveries.Rules
{
    public class DeliveryBusinessRules : BaseBusinessRules
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderDetailService _orderDetailService;

        public DeliveryBusinessRules(IDeliveryService deliveryService, IOrderDetailService orderDetailService)
        {
            _deliveryService = deliveryService;
            _orderDetailService = orderDetailService;
        }

        public async Task CheckIfOrderDetailExist(int orderDetailId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(orderDetailId);

            if (orderDetail == null) throw new BusinessException(DeliveryMessages.OrderDetailIdNotFound);
        }

        public async Task<Delivery> CheckIfDeliveryExists(int id)
        {
            var delivery = await _deliveryService.GetDeliveryById(id);

            if(delivery == null) throw new BusinessException(DeliveryMessages.DeliveryNotFound);

            return delivery;
        }

        public void CheckIfDeliveryListEmpty(IPaginate<Delivery> deliveries)
        {
            if (deliveries.Items.Count == 0) throw new BusinessException(DeliveryMessages.DeliveryListIsEmpty);
        }
    }
}
