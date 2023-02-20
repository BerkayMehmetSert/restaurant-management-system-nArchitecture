using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.Customers.Constants;
using Project.Application.Services.CustomerService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Customers.Rules
{
    public class CustomerBusinessRules : BaseBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;

        public CustomerBusinessRules(ICustomerService customerService, ICustomerRepository customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }

        public async Task CheckIfCustomerUsernameExists(string username)
        {
            var customer = await _customerRepository.GetAsync(x => x.Username == username);
            if (customer != null) throw new BusinessException(CustomerMessages.CustomerUsernameAlreadyExist);
        }

        public async Task<Customer> CheckIfCustomerExists(int id)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == id);
            if (customer == null) throw new BusinessException(CustomerMessages.CustomerNotFound);
            return customer;
        }

        public void CheckIfCustomerListEmpty(IPaginate<Customer> customers)
        {
            if (customers.Items.Count == 0) throw new BusinessException(CustomerMessages.CustomerListEmpty);
        }
    }
}
