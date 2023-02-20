using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Crews.Dto;

namespace Project.Application.Features.Crews.Models
{
    public class CrewListModel : BasePageableModel
    {
        public IList<CrewListDto> Items { get; set; }
    }
}
