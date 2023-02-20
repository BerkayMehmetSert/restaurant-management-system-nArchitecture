using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.OrderDetails.Constants;

namespace Project.Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
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
