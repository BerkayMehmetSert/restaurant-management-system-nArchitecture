using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.CustomerService
{
    public interface ICustomerService
    {
        public Task<Customer> GetCustomerById(int id);
    }
}
