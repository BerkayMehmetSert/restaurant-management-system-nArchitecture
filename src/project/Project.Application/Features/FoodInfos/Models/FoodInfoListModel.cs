using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.FoodInfos.Dto;

namespace Project.Application.Features.FoodInfos.Models
{
    public class FoodInfoListModel : BasePageableModel
    {
        public IList<FoodInfoListDto> Items { get; set; }
    }
}
