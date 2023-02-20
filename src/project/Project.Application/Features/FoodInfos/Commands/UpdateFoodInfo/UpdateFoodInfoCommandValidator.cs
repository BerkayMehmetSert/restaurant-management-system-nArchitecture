using FluentValidation;
using Project.Application.Features.FoodInfos.Constants;

namespace Project.Application.Features.FoodInfos.Commands.UpdateFoodInfo
{
    public class UpdateFoodInfoCommandValidator : AbstractValidator<UpdateFoodInfoCommand>
    {
        public UpdateFoodInfoCommandValidator()
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
