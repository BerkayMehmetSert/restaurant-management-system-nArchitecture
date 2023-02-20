using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Payments.Constants
{
    public static class PaymentMessages
    {
        public const string PaymentNotFound = "Payment not found";
        public const string PaymentListEmpty = "Payment list is empty";
        public const string CustomerIdIsRequired = "Customer id is required";
        public const string OrderDetailIdIsRequired = "OrderDetail id is required";
        public const string DeliveryIdIsRequired = "Delivery id is required";

        public const string CustomerNotFound = "Customer not found by id";
        public const string OrderDetailNotFound = "OrderDetail not found by id";
        public const string DeliveryNotFound = "Delivery not found by id";
    }
}
