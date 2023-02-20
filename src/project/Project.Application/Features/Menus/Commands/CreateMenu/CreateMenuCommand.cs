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

namespace Project.Application.Features.Menus.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<CreatedMenuDto>
    {
        public int FoodInfoId { get; set; }
        public string Details { get; set; }

        public class CreateMeuCommandHandler : IRequestHandler<CreateMenuCommand, CreatedMenuDto>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public CreateMeuCommandHandler(IMenuRepository menuRepository,
                IMapper mapper,
                MenuBusinessRules menuBusinessRules)
            {
                _menuRepository = menuRepository;
                _mapper = mapper;
                _menuBusinessRules = menuBusinessRules;
            }

            public async Task<CreatedMenuDto> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
            {
                await _menuBusinessRules.CheckIfFoodInfoExists(request.FoodInfoId);

                var requestToEntity = _mapper.Map<Menu>(request);

                var create = await _menuRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedMenuDto>(create);

                return result;
            }
        }
    }
}
