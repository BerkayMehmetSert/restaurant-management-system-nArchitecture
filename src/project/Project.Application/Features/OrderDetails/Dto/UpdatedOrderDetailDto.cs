using Core.Application.Dto;

namespace Project.Application.Features.OrderDetails.Dto;

public class UpdatedOrderDetailDto : IDto
{
    public int Id { get; set; }
    public int CrewId { get; set; }
    public int CustomerId { get; set; }
    public int FoodInfoId { get; set; }
    public string Status { get; set; }
}