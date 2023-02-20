using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.FoodInfos.Models;
using Project.Application.Features.FoodInfos.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.FoodInfos.Queries.GetAllFoodInfo
{
    public class GetAllFoodInfoQuery : IRequest<FoodInfoListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllFoodInfoQueryHandler : IRequestHandler<GetAllFoodInfoQuery, FoodInfoListModel>
        {
            private readonly IFoodInfoRepository _foodInfoRepository;
            private readonly IMapper _mapper;
            private readonly FoodInfoBusinessRules _foodInfoBusinessRules;
            public GetAllFoodInfoQueryHandler(IFoodInfoRepository foodInfoRepository,
                FoodInfoBusinessRules foodInfoBusinessRules, IMapper mapper)
            {
                _foodInfoRepository = foodInfoRepository;
                _foodInfoBusinessRules = foodInfoBusinessRules;
                _mapper = mapper;
            }

            public async Task<FoodInfoListModel> Handle(GetAllFoodInfoQuery request,
                CancellationToken cancellationToken)
            {
                var foods = await _foodInfoRepository.GetListAsync(
                    include:
                    x => x.Include(y => y.OrderDetails)
                        .Include(y => y.Menus),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                    );

                _foodInfoBusinessRules.CheckIfFoodInfoListEmpty(foods);

                var result = _mapper.Map<FoodInfoListModel>(foods);

                return result;
            }
        }
    }
}
