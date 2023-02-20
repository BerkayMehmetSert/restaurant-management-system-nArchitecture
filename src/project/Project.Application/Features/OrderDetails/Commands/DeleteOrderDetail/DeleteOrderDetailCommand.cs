using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.OrderDetails.Dto;
using Project.Application.Features.OrderDetails.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.OrderDetails.Commands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommand : IRequest<DeletedOrderDetailDto>
    {
        public int Id { get; set; }

        public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, DeletedOrderDetailDto>
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;
            private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

            public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository,
                IMapper mapper, OrderDetailBusinessRules orderDetailBusinessRules)
            {
                _orderDetailRepository = orderDetailRepository;
                _mapper = mapper;
                _orderDetailBusinessRules = orderDetailBusinessRules;
            }

            public async Task<DeletedOrderDetailDto> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var orderDetail = await _orderDetailBusinessRules.CheckIfOrderDetailExistById(request.Id);

                var delete = await _orderDetailRepository.DeleteAsync(orderDetail);

                var result = _mapper.Map<DeletedOrderDetailDto>(delete);

                return result;
            }
        }
    }
}
