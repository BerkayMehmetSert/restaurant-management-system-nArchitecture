using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Delivery : Entity
    {
        public int OrderDetailId { get; set; }

        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public Delivery()
        {
            Payments = new HashSet<Payment>();
        }

        public Delivery(int id, int orderDetailId) : this()
        {
            Id = id;
            OrderDetailId = orderDetailId;
        }
    }
}
