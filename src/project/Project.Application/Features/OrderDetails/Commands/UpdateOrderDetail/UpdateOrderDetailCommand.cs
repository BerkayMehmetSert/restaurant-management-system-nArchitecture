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

namespace Project.Application.Features.OrderDetails.Commands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommand : IRequest<UpdatedOrderDetailDto>
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public int CustomerId { get; set; }
        public int FoodInfoId { get; set; }
        public string Status { get; set; }

        public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, UpdatedOrderDetailDto>
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;
            private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

            public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository,
                IMapper mapper, OrderDetailBusinessRules orderDetailBusinessRules)
            {
                _orderDetailRepository = orderDetailRepository;
                _mapper = mapper;
                _orderDetailBusinessRules = orderDetailBusinessRules;
            }

            public async Task<UpdatedOrderDetailDto> Handle(UpdateOrderDetailCommand request,
                CancellationToken cancellationToken)
            {
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByCrewId(request.CrewId);
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByCustomerId(request.CustomerId);
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByFoodInfoId(request.FoodInfoId);

                var orderDetail = await _orderDetailBusinessRules.CheckIfOrderDetailExistById(request.Id);

                orderDetail.CrewId = request.CrewId;
                orderDetail.CustomerId = request.CustomerId;
                orderDetail.FoodInfoId = request.FoodInfoId;
                orderDetail.Status = request.Status;


                var update = await _orderDetailRepository.UpdateAsync(orderDetail);

                var result = _mapper.Map<UpdatedOrderDetailDto>(update);

                return result;
            }
        }
    }
}
