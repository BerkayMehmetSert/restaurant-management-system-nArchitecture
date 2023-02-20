using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.OrderDetailService
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            var result = await _orderDetailRepository.GetAsync(x => x.Id == id);
            return result!;
        }
    }
}
