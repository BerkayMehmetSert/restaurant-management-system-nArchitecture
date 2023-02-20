using Core.Application.Dto;

namespace Project.Application.Features.Deliveries.Dto;

public class UpdatedDeliveryDto : IDto
{
    public int Id { get; set; }
    public int OrderDetailId { get; set; }
}