using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Menus.Dto;

namespace Project.Application.Features.Menus.Models
{
    public class MenuListModel : BasePageableModel
    {
        public IList<MenuListDto> Items { get; set; }
    }
}
