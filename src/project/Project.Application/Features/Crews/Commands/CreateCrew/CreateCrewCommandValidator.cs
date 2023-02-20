using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.Crews.Constants;

namespace Project.Application.Features.Crews.Commands.CreateCrew
{
    public class CreateCrewCommandValidator : AbstractValidator<CreateCrewCommand>
    {
        public CreateCrewCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage(CrewMessages.CrewNameIsRequired);
            RuleFor(x=>x.Name)
                .MinimumLength(2)
                .WithMessage(CrewMessages.CrewNameMinimumLength);
            RuleFor(x=>x.Contact)
                .NotEmpty()
                .WithMessage(CrewMessages.CrewContactIsRequired);   
            RuleFor(x=>x.Address)
                .NotEmpty()
                .WithMessage(CrewMessages.CrewAddressIsRequired);
            RuleFor(x=>x.Username)
                .NotEmpty()
                .WithMessage(CrewMessages.CrewUsernameIsRequired);
            RuleFor(x=>x.Username)
                .MinimumLength(4)
                .WithMessage(CrewMessages.CrewUsernameMinimumLength);
            RuleFor(x=>x.Password)
                .NotEmpty()
                .WithMessage(CrewMessages.CrewPasswordIsRequired);
            RuleFor(x=>x.Password)
                .MinimumLength(4)
                .WithMessage(CrewMessages.CrewPasswordMinimumLength);
        }
    }
}
