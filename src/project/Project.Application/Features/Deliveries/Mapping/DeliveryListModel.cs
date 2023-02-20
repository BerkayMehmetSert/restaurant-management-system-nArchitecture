using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Deliveries.Dto;

namespace Project.Application.Features.Deliveries.Mapping
{
    public class DeliveryListModel : BasePageableModel
    {
        public IList<DeliveryListDto> Items { get; set; } 
    }
}
