using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.OrderDetails.Constants
{
    public static class OrderDetailMessages
    {
        public const string OrderDetailCustomerNotFound = "Customer not found";
        public const string OrderDetailCrewNotFound = "Crew not found";
        public const string OrderDetailFoodInfoNotFound = "FoodInfo not found";
        public const string OrderDetailNotFound = "OrderDetail not found";
        public const string OrderDetailListEmpty = "OrderDetail list is empty";

        public const string CrewIdIsRequired = "CrewId is required";
        public const string CustomerIdIsRequired = "CustomerId is required";
        public const string FoodInfoIdIsRequired = "FoodInfoId is required";
        public const string StatusIsRequired = "Status is required";
        public const string StatusMinimumLength = "Status minimum length is 3";
    }
}
