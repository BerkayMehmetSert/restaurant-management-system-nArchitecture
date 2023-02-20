using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class OrderDetail : Entity
    {
        public int CrewId { get; set; }
        public int CustomerId { get; set; }
        public int FoodInfoId { get; set; }
        public string Status { get; set; }

        public virtual Crew? Crew { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual FoodInfo? FoodInfo { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public OrderDetail()
        {
            Payments = new HashSet<Payment>();
        }

        public OrderDetail(int id, int crewId, int customerId, int foodInfoId, string status) : this()
        {
            Id = id;
            CrewId = crewId;
            CustomerId = customerId;
            FoodInfoId = foodInfoId;
            Status = status;
        }
    }
}
