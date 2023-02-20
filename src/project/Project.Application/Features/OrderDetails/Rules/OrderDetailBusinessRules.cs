using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.OrderDetails.Constants;
using Project.Application.Services.CrewService;
using Project.Application.Services.CustomerService;
using Project.Application.Services.FoodInfoService;
using Project.Application.Services.OrderDetailService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.OrderDetails.Rules
{
    public class OrderDetailBusinessRules : BaseBusinessRules
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICustomerService _customerService;
        private readonly ICrewService _crewService;
        private readonly IFoodInfoService _foodInfoService;

        public OrderDetailBusinessRules(IOrderDetailRepository orderDetailRepository,
            IOrderDetailService orderDetailService, ICustomerService customerService, 
            ICrewService crewService, IFoodInfoService foodInfoService)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderDetailService = orderDetailService;
            _customerService = customerService;
            _crewService = crewService;
            _foodInfoService = foodInfoService;
        }

        public async Task CheckIfOrderDetailExistByCustomerId(int customerId)
        {
            var orderDetail = await _customerService.GetCustomerById(customerId);
            if (orderDetail == null) throw new BusinessException(OrderDetailMessages.OrderDetailCustomerNotFound);
        }

        public async Task CheckIfOrderDetailExistByCrewId(int crewId)
        {
            var orderDetail = await _crewService.GetCrewById(crewId);
            if (orderDetail == null) throw new BusinessException(OrderDetailMessages.OrderDetailCrewNotFound);
        }

        public async Task CheckIfOrderDetailExistByFoodInfoId(int foodInfoId)
        {
            var orderDetail = await _foodInfoService.GetFoodInfoById(foodInfoId);
            if (orderDetail == null) throw new BusinessException(OrderDetailMessages.OrderDetailFoodInfoNotFound);
        }

        public async Task<OrderDetail> CheckIfOrderDetailExistById(int id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(id);
            if (orderDetail == null) throw new BusinessException(OrderDetailMessages.OrderDetailNotFound);
            return orderDetail;
        }

        public void CheckIfOrderDetailListEmpty(IPaginate<OrderDetail> orderDetaiils)
        {
            if (orderDetaiils.Items.Count == 0) throw new BusinessException(OrderDetailMessages.OrderDetailListEmpty);
        }

    }
}
