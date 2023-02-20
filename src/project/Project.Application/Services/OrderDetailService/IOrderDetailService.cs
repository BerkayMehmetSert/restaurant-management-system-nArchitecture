using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.OrderDetailService
{
    public interface IOrderDetailService
    {
        public Task<OrderDetail> GetOrderDetailById(int id);
    }
}
