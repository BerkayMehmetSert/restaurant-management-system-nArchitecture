using Core.Application.Dto;

namespace Project.Application.Features.FoodInfos.Dto;

public class UpdatedFoodInfoDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public double Price { get; set; }
}