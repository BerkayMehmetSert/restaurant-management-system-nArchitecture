using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.FoodInfos.Constants;

namespace Project.Application.Features.FoodInfos.Commands.CreateFoodInfo
{
    public class CreateFoodInfoCommandValidator : AbstractValidator<CreateFoodInfoCommand>
    {
        public CreateFoodInfoCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage(FoodInfoMessage.FoodNameRequired);

            RuleFor(x=>x.Name)
                .MinimumLength(3)
                .WithMessage(FoodInfoMessage.FoodNameMinimumLength);

            RuleFor(x=>x.Status)
                .NotEmpty()
                .WithMessage(FoodInfoMessage.FoodStatusRequired);
            RuleFor(x=>x.Price)
                .NotEmpty()
                .WithMessage(FoodInfoMessage.FoodPriceRequired);

            RuleFor(x=>x.Price)
                .GreaterThan(0)
                .WithMessage(FoodInfoMessage.FoodPriceGreaterThanZero);
        }
    }
}
