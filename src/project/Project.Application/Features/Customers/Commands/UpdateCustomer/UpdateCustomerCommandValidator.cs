using FluentValidation;
using Project.Application.Features.Customers.Constants;

namespace Project.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage(CustomerMessages.CustomerNameIsRequired);

            RuleFor(x=>x.Name)
                .MinimumLength(2)
                .WithMessage(CustomerMessages.CustomerNameMinimumLength);

            RuleFor(x=>x.Contact)
                .NotEmpty()
                .WithMessage(CustomerMessages.CustomerContactIsRequired);

            RuleFor(x=>x.Address)
                .NotEmpty()
                .WithMessage(CustomerMessages.CustomerAddressIsRequired);

            RuleFor(x=>x.Username)
                .NotEmpty()
                .WithMessage(CustomerMessages.CustomerUsernameIsRequired);

            RuleFor(x=>x.Username)
                .MinimumLength(4)
                .WithMessage(CustomerMessages.CustomerUsernameMinimumLength);

            RuleFor(x=>x.Password)
                .NotEmpty()
                .WithMessage(CustomerMessages.CustomerPasswordIsRequired);

            RuleFor(x=>x.Password)
                .MinimumLength(4)
                .WithMessage(CustomerMessages.CustomerPasswordMinimumLength);
            
        }
    }
}
