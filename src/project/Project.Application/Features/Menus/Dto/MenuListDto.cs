﻿using Core.Application.Dto;

namespace Project.Application.Features.Menus.Dto;

public class MenuListDto : IDto
{
    public int Id { get; set; }
    public int FoodInfoId { get; set; }
    public string Details { get; set; }
}