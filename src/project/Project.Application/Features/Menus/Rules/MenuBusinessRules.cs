using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Features.Menus.Constants;
using Project.Application.Services.FoodInfoService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Menus.Rules
{
    public class MenuBusinessRules : BaseBusinessRules
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IFoodInfoService _foodInfoService;

        public MenuBusinessRules(IMenuRepository menuRepository, IFoodInfoService foodInfoService)
        {
            _menuRepository = menuRepository;
            _foodInfoService = foodInfoService;
        }

        public async Task CheckIfFoodInfoExists(int foodInfoId)
        {
            var foodInfo = await _foodInfoService.GetFoodInfoById(foodInfoId);

            if (foodInfo == null) throw new BusinessException(MenuMessages.MenuNotFoundByFoodInfoId);
        }

        public async Task<Menu> CheckIfMenuExists(int id)
        {
            var menu = await _menuRepository.GetAsync(x => x.Id == id);

            if (menu == null) throw new BusinessException(MenuMessages.MenuNotFound);

            return menu;
        }

        public void CheckIfMenuListEmpty(IPaginate<Menu> menus)
        {
            if (menus.Items.Count == 0) throw new BusinessException(MenuMessages.MenuListEmpty);
        }
    }
}
