using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Menus.Dto;
using Project.Application.Features.Menus.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommand : IRequest<DeletedMenuDto>
    {
        public int Id { get; set; }

        public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, DeletedMenuDto>
        {
            private readonly IMenuRepository _menuRepository;
            private readonly IMapper _mapper;
            private readonly MenuBusinessRules _menuBusinessRules;

            public DeleteMenuCommandHandler(IMenuRepository menuRepository,
                IMapper mapper, MenuBusinessRules menuBusinessRules)
            {
                _menuRepository = menuRepository;
                _mapper = mapper;
                _menuBusinessRules = menuBusinessRules;
            }

            public async Task<DeletedMenuDto> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
            {
                var menu = await _menuBusinessRules.CheckIfMenuExists(request.Id);

                var delete = await _menuRepository.DeleteAsync(menu);

                var result = _mapper.Map<DeletedMenuDto>(delete);

                return result;
            }
        }
    }
}
