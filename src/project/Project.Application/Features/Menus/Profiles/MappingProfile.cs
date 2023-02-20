using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Menus.Commands.CreateMenu;
using Project.Application.Features.Menus.Commands.DeleteMenu;
using Project.Application.Features.Menus.Commands.UpdateMenu;
using Project.Application.Features.Menus.Dto;
using Project.Application.Features.Menus.Models;
using Project.Domain.Entities;

namespace Project.Application.Features.Menus.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, CreateMenuCommand>().ReverseMap();
            CreateMap<Menu, CreatedMenuDto>().ReverseMap();
            CreateMap<Menu, UpdateMenuCommand>().ReverseMap();
            CreateMap<Menu, UpdatedMenuDto>().ReverseMap();
            CreateMap<Menu, DeleteMenuCommand>().ReverseMap();
            CreateMap<Menu, DeletedMenuDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, MenuListDto>().ReverseMap();
            CreateMap<IPaginate<Menu>, MenuListModel>();
        }
    }
}
