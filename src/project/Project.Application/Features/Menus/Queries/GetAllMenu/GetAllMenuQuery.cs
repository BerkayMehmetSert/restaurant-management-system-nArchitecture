using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Project.Application.Features.Menus.Models;
using Project.Application.Features.Menus.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Menus.Queries.GetAllMenu
{
    public class GetAllMenuQuery : IRequest<MenuListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQuery, MenuListModel>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public GetAllMenuQueryHandler(IMenuRepository menuRepository, IMapper mapper,
                MenuBusinessRules menuBusinessRules)
            {
                _menuRepository = menuRepository;
                _mapper = mapper;
                _menuBusinessRules = menuBusinessRules;
            }

            public async Task<MenuListModel> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
            {
                var menus = await _menuRepository.GetListAsync(
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                    );

                _menuBusinessRules.CheckIfMenuListEmpty(menus);

                var result = _mapper.Map<MenuListModel>(menus);

                return result;
            }
        }
    }
}
