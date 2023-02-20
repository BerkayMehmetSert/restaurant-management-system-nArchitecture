using Core.Application.Dto;

namespace Project.Application.Features.Crews.Dto;

public class CrewListDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }

    public IList<CrewTransactionReportDto> TransactionReports { get; set; }
    public IList<CrewOrderDetailDto> OrderDetails { get; set; }
}