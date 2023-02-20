using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.Deliveries.Constants;

namespace Project.Application.Features.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandValidator : AbstractValidator<CreateDeliveryCommand>
    {
        public CreateDeliveryCommandValidator()
        {
            RuleFor(x=>x.OrderDetailId)
                .NotEmpty()
                .WithMessage(DeliveryMessages.OrderDetailIdIsRequired);
        }
    }
}
