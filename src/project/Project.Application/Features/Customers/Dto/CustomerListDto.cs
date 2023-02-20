namespace Project.Application.Features.Customers.Dto;

public class CustomerListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }

    public IList<CustomerOrderDetailDto> OrderDetails { get; set; }
    public IList<CustomerTransactionReportDto> TransactionReports { get; set; }
    public IList<CustomerPaymentDto> Payments{ get; set; }
}