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

namespace Project.Application.Features.Menus.Queries.GetByIdMenu
{
    public class GetByIdMenuQuery : IRequest<MenuDto>
    {
        public int Id { get; set; }

        public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQuery, MenuDto>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public GetByIdMenuQueryHandler(IMenuRepository menuRepository, 
                MenuBusinessRules menuBusinessRules, IMapper mapper)
            {
                _menuRepository = menuRepository;
                _menuBusinessRules = menuBusinessRules;
                _mapper = mapper;
            }

            public async Task<MenuDto> Handle(GetByIdMenuQuery request, CancellationToken cancellationToken)
            {
                var menu = await _menuBusinessRules.CheckIfMenuExists(request.Id);

                var result = _mapper.Map<MenuDto>(menu);

                return result;
            }
        }
    }
}
