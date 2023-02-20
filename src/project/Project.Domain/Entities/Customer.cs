using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TransactionReport> TransactionReports { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public Customer()
        {
            TransactionReports = new HashSet<TransactionReport>();
            OrderDetails = new HashSet<OrderDetail>();
            Payments = new HashSet<Payment>();
        }

        public Customer(int id,string name, string contact, string address, string username, string password) : this()
        {
            Id = id;
            Name = name;
            Contact = contact;
            Address = address;
            Username = username;
            Password = password;
        }
    }
}
