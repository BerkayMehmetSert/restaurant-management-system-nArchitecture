using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Payments.Dto;

namespace Project.Application.Features.Payments.Models
{
    public class PaymentListModel : BasePageableModel
    {
        public IList<PaymentListDto> Items { get; set; }
    }
}
