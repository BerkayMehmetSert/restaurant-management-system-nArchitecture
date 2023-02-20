using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Menu : Entity
    {
        public int FoodInfoId { get; set; }
        public string Details { get; set; }

        public virtual FoodInfo? FoodInfo { get; set; }

        public Menu()
        {
            
        }

        public Menu(int id, int foodInfoId, string details) : this()
        {
            Id = id;
            FoodInfoId = foodInfoId;
            Details = details;
        }
    }
}
