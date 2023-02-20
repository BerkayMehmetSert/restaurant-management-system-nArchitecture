using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.TransactionReports.Dto;

namespace Project.Application.Features.TransactionReports.Models
{
    public class TransactionReportListModel : BasePageableModel
    {
        public IList<TransactionReportListDto> Items { get; set; }
    }
}
