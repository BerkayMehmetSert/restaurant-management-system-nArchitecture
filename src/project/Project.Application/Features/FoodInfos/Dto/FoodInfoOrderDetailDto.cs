using Core.Application.Dto;

namespace Project.Application.Features.FoodInfos.Dto;

public class FoodInfoOrderDetailDto : IDto
{
    public int Id { get; set; }
    public int CrewId { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; }
}