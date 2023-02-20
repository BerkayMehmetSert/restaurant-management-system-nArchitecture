using Core.Application.Dto;

namespace Project.Application.Features.OrderDetails.Dto;

public class OrderDetailPaymentDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int DeliveryId { get; set; }
    public double Amount { get; set; }
}