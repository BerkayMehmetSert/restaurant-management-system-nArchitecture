using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class TransactionReport : Entity
    {
        public int CustomerId { get; set; }
        public int CrewId { get; set; }
        public int OrderDetailId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Crew? Crew { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }

        public TransactionReport()
        {
            
        }

        public TransactionReport(int id, int customerId, int crewId, int orderDetailId) : this()
        {
            Id = id;
            CustomerId = customerId;
            CrewId = crewId;
            OrderDetailId = orderDetailId;
        }
    }
}
