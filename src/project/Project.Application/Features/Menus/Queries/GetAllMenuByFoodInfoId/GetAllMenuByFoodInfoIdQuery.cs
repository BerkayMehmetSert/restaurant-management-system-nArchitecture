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

namespace Project.Application.Features.Menus.Queries.GetAllMenuByFoodInfoId
{
    public class GetAllMenuByFoodInfoIdQuery : IRequest<MenuListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int foodInfoId { get; set; }

        public class GetAllMenuByFoodInfoIdQueryHandler : IRequestHandler<GetAllMenuByFoodInfoIdQuery, MenuListModel>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public GetAllMenuByFoodInfoIdQueryHandler(IMenuRepository menuRepository,
                IMapper mapper, MenuBusinessRules menuBusinessRules)
            {
                _menuRepository = menuRepository;
                _mapper = mapper;
                _menuBusinessRules = menuBusinessRules;
            }

            public async Task<MenuListModel> Handle(GetAllMenuByFoodInfoIdQuery request, CancellationToken cancellationToken)
            {
                await _menuBusinessRules.CheckIfFoodInfoExists(request.foodInfoId);

                var menus = await _menuRepository.GetListAsync(
                    x => x.FoodInfoId == request.foodInfoId,
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                    );

                var result = _mapper.Map<MenuListModel>(menus);

                return result;
            }
        }
    }
}
