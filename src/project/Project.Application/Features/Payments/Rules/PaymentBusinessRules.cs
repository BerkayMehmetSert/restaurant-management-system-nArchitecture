using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.Payments.Constants;
using Project.Application.Services.CustomerService;
using Project.Application.Services.DeliveryService;
using Project.Application.Services.OrderDetailService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Payments.Rules
{
    public class PaymentBusinessRules : BaseBusinessRules
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICustomerService _customerService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IDeliveryService _deliveryService;

        public PaymentBusinessRules(IPaymentRepository paymentRepository, ICustomerService customerService,
            IOrderDetailService orderDetailService, IDeliveryService deliveryService)
        {
            _paymentRepository = paymentRepository;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
            _deliveryService = deliveryService;
        }

        public async Task<Payment> CheckPaymentExist(int id)
        {
            var payment = await _paymentRepository.GetAsync(x => x.Id == id);
            if (payment == null) throw new BusinessException(PaymentMessages.PaymentNotFound);

            return payment;
        }

        public void CheckICustomerIdExists(int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);

            if (customer == null) throw new BusinessException(PaymentMessages.CustomerNotFound);
        }

        public void CheckOrderDetailIdExists(int orderDetailId)
        {
            var orderDetail = _orderDetailService.GetOrderDetailById(orderDetailId);

            if (orderDetail == null) throw new BusinessException(PaymentMessages.OrderDetailNotFound);
        }

        public void CheckDeliveryIdExists(int deliveryId)
        {
            var delivery = _deliveryService.GetDeliveryById(deliveryId);

            if (delivery == null) throw new BusinessException(PaymentMessages.DeliveryNotFound);
        }

        public void CheckIfPaymentListEmpty(IPaginate<Payment> payments)
        {
            if (payments.Items.Count == 0) throw new BusinessException(PaymentMessages.PaymentListEmpty);
        }
    }
}
