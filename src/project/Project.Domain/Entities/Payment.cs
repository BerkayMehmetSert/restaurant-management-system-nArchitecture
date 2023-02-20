using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Payment : Entity
    {
        public int CustomerId { get; set; }
        public int OrderDetailId { get; set; }
        public int DeliveryId { get; set; }
        public double Amount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual Delivery? Delivery { get; set; }

        public Payment()
        {
            
        }

        public Payment(int id, int customerId, int orderDetailId, int deliveryId, double amount) : this()
        {
            Id = id;
            CustomerId = customerId;
            OrderDetailId = orderDetailId;
            DeliveryId = deliveryId;
            Amount = amount;
        }
    }
}
