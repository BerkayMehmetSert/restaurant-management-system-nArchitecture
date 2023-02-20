using Core.Application.Dto;

namespace Project.Application.Features.Menus.Dto;

public class DeletedMenuDto : IDto
{
    public int Id { get; set; }
    public int FoodInfoId { get; set; }
    public string Details { get; set; }
}