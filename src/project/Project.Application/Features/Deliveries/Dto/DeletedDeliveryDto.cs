using Core.Application.Dto;

namespace Project.Application.Features.Deliveries.Dto;

public class DeletedDeliveryDto : IDto
{
    public int Id { get; set; }
    public int OrderDetailId { get; set; }
}