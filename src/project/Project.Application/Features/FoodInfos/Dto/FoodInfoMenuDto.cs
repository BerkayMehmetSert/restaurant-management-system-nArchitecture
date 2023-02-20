using Core.Application.Dto;

namespace Project.Application.Features.FoodInfos.Dto;

public class FoodInfoMenuDto : IDto
{
    public int Id { get; set; }
    public string Details { get; set; }
}