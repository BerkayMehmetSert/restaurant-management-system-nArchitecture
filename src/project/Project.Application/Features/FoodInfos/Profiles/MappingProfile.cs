using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.FoodInfos.Commands.CreateFoodInfo;
using Project.Application.Features.FoodInfos.Commands.DeleteFoodInfo;
using Project.Application.Features.FoodInfos.Commands.UpdateFoodInfo;
using Project.Application.Features.FoodInfos.Dto;
using Project.Application.Features.FoodInfos.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.FoodInfos.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodInfo, CreateFoodInfoCommand>().ReverseMap();
            CreateMap<FoodInfo, CreatedFoodInfoDto>().ReverseMap();
            CreateMap<FoodInfo, UpdateFoodInfoCommand>().ReverseMap();
            CreateMap<FoodInfo, UpdatedFoodInfoDto>().ReverseMap();
            CreateMap<FoodInfo, DeleteFoodInfoCommand>().ReverseMap();
            CreateMap<FoodInfo, DeletedFoodInfoDto>().ReverseMap();
            CreateMap<FoodInfo, FoodInfoDto>().ReverseMap();
            CreateMap<FoodInfo, FoodInfoListDto>().ReverseMap();
            CreateMap<Menu, FoodInfoMenuDto>().ReverseMap();
            CreateMap<OrderDetail, FoodInfoOrderDetailDto>().ReverseMap();
            CreateMap<IPaginate<FoodInfo>, FoodInfoListModel>().ReverseMap();
        }
    }
}
