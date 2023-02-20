using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.Menus.Constants;

namespace Project.Application.Features.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(x => x.FoodInfoId)
                .NotEmpty()
                .WithMessage(MenuMessages.FoodInfoIsRequired);

            RuleFor(x=>x.Details)
                .NotEmpty()
                .WithMessage(MenuMessages.DetailsIsRequired);
        }
    }
}
