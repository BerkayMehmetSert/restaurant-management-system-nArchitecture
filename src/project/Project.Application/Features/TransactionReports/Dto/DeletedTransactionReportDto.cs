using Core.Application.Dto;

namespace Project.Application.Features.TransactionReports.Dto;

public class DeletedTransactionReportDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CrewId { get; set; }
    public int OrderDetailId { get; set; }
}