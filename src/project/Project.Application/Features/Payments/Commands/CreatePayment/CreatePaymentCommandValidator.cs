using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.Payments.Constants;

namespace Project.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage(PaymentMessages.CustomerIdIsRequired);

            RuleFor(x => x.OrderDetailId)
                .NotEmpty()
                .WithMessage(PaymentMessages.OrderDetailIdIsRequired);

            RuleFor(x => x.DeliveryId)
                .NotEmpty()
                .WithMessage(PaymentMessages.DeliveryIdIsRequired);
        }
    }
}
