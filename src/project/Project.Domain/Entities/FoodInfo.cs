using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class FoodInfo : Entity
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public FoodInfo()
        {
            Menus = new HashSet<Menu>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public FoodInfo(int id, string name, string status, double price) : this()
        {
            Id = id;
            Name = name;
            Status = status;
            Price = price;
        }
    }
}
