using FluentValidation;
using Project.Application.Features.OrderDetails.Constants;

namespace Project.Application.Features.OrderDetails.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailCommandValidator()
        {
            RuleFor(x => x.CrewId)
                .NotEmpty()
                .WithMessage(OrderDetailMessages.CrewIdIsRequired);

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage(OrderDetailMessages.CustomerIdIsRequired);

            RuleFor(x => x.FoodInfoId)
                .NotEmpty()
                .WithMessage(OrderDetailMessages.FoodInfoIdIsRequired);

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage(OrderDetailMessages.StatusIsRequired);

            RuleFor(x => x.Status)
                .MinimumLength(3)
                .WithMessage(OrderDetailMessages.StatusMinimumLength);
        }
    }
}
