using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Customers.Dto;

namespace Project.Application.Features.Customers.Models
{
    public class CustomerListModel : BasePageableModel
    {
        public IList<CustomerListDto> Items { get; set; }
    }
}
