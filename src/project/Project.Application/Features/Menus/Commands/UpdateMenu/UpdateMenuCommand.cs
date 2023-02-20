using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Menus.Dto;
using Project.Application.Features.Menus.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommand : IRequest<UpdatedMenuDto>
    {
        public int Id { get; set; }
        public int FoodInfoId { get; set; }
        public string Details { get; set; }

        public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, UpdatedMenuDto>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public UpdateMenuCommandHandler(IMenuRepository menuRepository,
                IMapper mapper, MenuBusinessRules menuBusinessRules)
            {
                _menuRepository = menuRepository;
                _mapper = mapper;
                _menuBusinessRules = menuBusinessRules;
            }

            public async Task<UpdatedMenuDto> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
            {
                var menu = await _menuBusinessRules.CheckIfMenuExists(request.Id);

                await _menuBusinessRules.CheckIfFoodInfoExists(request.FoodInfoId);

                menu.Details = request.Details;
                menu.FoodInfoId = request.FoodInfoId;

                var update = await _menuRepository.UpdateAsync(menu);

                var result = _mapper.Map<UpdatedMenuDto>(update);

                return result;
            }
        }
    }
}
