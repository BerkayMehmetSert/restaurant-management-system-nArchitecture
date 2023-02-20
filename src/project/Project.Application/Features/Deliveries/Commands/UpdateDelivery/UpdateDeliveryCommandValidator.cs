using FluentValidation;
using Project.Application.Features.Deliveries.Constants;

namespace Project.Application.Features.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandValidator : AbstractValidator<UpdateDeliveryCommand>
    {
        public UpdateDeliveryCommandValidator()
        {
            RuleFor(x=>x.OrderDetailId)
                .NotEmpty()
                .WithMessage(DeliveryMessages.OrderDetailIdIsRequired);
        }
    }
}
