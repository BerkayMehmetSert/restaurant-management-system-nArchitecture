using Core.Application.Dto;

namespace Project.Application.Features.FoodInfos.Dto;

public class FoodInfoListDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public double Price { get; set; }

    public IList<FoodInfoMenuDto> Menus { get; set; }
    public IList<FoodInfoOrderDetailDto> OrderDetails { get; set; }
}