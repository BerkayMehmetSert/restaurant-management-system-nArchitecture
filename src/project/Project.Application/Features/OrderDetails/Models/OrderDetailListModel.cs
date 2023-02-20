using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.OrderDetails.Dto;

namespace Project.Application.Features.OrderDetails.Models
{
    public class OrderDetailListModel : BasePageableModel
    {
        public IList<OrderDetailListDto> Items { get; set; }
    }
}
