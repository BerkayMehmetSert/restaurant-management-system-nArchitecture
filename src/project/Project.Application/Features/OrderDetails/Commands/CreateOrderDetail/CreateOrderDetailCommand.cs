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
using Project.Domain.Entities;

namespace Project.Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    public class CreateOrderDetailCommand : IRequest<CreatedOrderDetailDto>
    {
        public int CrewId { get; set; }
        public int CustomerId { get; set; }
        public int FoodInfoId { get; set; }
        public string Status { get; set; }

        public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreatedOrderDetailDto>
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;
            private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

            public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, 
                IMapper mapper, OrderDetailBusinessRules orderDetailBusinessRules)
            {
                _orderDetailRepository = orderDetailRepository;
                _mapper = mapper;
                _orderDetailBusinessRules = orderDetailBusinessRules;
            }

            public async Task<CreatedOrderDetailDto> Handle(CreateOrderDetailCommand request,
                CancellationToken cancellationToken)
            {
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByCustomerId(request.CustomerId);
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByCrewId(request.CrewId);
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByFoodInfoId(request.FoodInfoId);

                var requestToEntity = _mapper.Map<OrderDetail>(request);

                var create = await _orderDetailRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedOrderDetailDto>(create);

                return result;
            }
        }
    }
}
