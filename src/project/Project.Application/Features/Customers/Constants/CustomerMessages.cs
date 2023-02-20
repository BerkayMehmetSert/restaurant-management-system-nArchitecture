using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Customers.Constants
{
    public static class CustomerMessages
    {
        public const string CustomerUsernameAlreadyExist = "Customer username already exist";
        public const string CustomerNotFound = "Customer not found";
        public const string CustomerListEmpty = "Customer list is empty";

        public const string CustomerUsernameIsRequired = "Customer username is required";
        public const string CustomerUsernameMinimumLength = "Customer username minimum length is 4";
        public const string CustomerPasswordIsRequired = "Customer password is required";
        public const string CustomerPasswordMinimumLength = "Customer password minimum length is 4";
        public const string CustomerNameIsRequired = "Customer name is required";
        public const string CustomerNameMinimumLength = "Customer name minimum length is 2";
        public const string CustomerContactIsRequired = "Customer contact is required";
        public const string CustomerAddressIsRequired = "Customer address is required";
        
    }
}
