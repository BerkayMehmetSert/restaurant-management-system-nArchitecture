using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.FoodInfos.Constants
{
    public static class FoodInfoMessage
    {
        public const string FoodNotFoundById = "Food not found by id";
        public const string FoodNameAlreadyExists = "Food name already exists";
        public const string FoodInfoListEmpty = "Food info list is empty";

        public const string FoodNameRequired = "Food name is required";
        public const string FoodNameMinimumLength = "Food name minimum length is 3";
        public const string FoodStatusRequired = "Food status is required";
        public const string FoodPriceRequired = "Food price is required";
        public const string FoodPriceGreaterThanZero = "Food price must be greater than zero";
    }
}
