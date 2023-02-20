namespace Project.Application.Features.Customers.Dto;

public class CustomerPaymentDto
{
    public int Id { get; set; }
    public int OrderDetailId { get; set; }
    public int DeliveryId { get; set; }
    public double Amount { get; set; }
}