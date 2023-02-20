using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Deliveries.Constants
{
    public static class DeliveryMessages
    {
        public const string OrderDetailIdNotFound = "OrderDetail id not found";
        public const string DeliveryNotFound = "Delivery not found by id";
        public const string DeliveryListIsEmpty = "Delivery list is empty";

        public const string OrderDetailIdIsRequired = "OrderDetail id is required";
    }
}
