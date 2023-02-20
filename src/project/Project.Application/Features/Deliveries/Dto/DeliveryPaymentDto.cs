using Core.Application.Dto;

namespace Project.Application.Features.Deliveries.Dto;

public class DeliveryPaymentDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderDetailId { get; set; }
    public double Amount { get; set; }
}