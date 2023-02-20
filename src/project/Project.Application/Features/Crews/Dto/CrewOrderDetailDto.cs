using Core.Application.Dto;

namespace Project.Application.Features.Crews.Dto;

public class CrewOrderDetailDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int FoodInfoId { get; set; }
    public string Status { get; set; }
}