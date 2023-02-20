using FluentValidation;
using Project.Application.Features.Menus.Constants;
using Project.Application.Features.Menus.Dto;

namespace Project.Application.Features.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommandValidator : AbstractValidator<UpdatedMenuDto>
    {
        public UpdateMenuCommandValidator()
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
