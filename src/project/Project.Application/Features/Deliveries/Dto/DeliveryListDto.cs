using Core.Application.Dto;

namespace Project.Application.Features.Deliveries.Dto;

public class DeliveryListDto : IDto
{
    public int Id { get; set; }
    public int OrderDetailId { get; set; }

    public IList<DeliveryPaymentDto> Payments { get; set; }
}