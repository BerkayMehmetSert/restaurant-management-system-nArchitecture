using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.OrderDetails.Models;
using Project.Application.Features.OrderDetails.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.OrderDetails.Queries.GetAllOrderDetailByCrewId
{
    public class GetAllOrderDetailByCrewIdQuery : IRequest<OrderDetailListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int CrewId { get; set; }

        public class GetAllOrderDetailByCrewIdQueryHandler : IRequestHandler<GetAllOrderDetailByCrewIdQuery, OrderDetailListModel>
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;
            private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

            public GetAllOrderDetailByCrewIdQueryHandler(IOrderDetailRepository orderDetailRepository,
                IMapper mapper, OrderDetailBusinessRules orderDetailBusinessRules)
            {
                _orderDetailRepository = orderDetailRepository;
                _mapper = mapper;
                _orderDetailBusinessRules = orderDetailBusinessRules;
            }

            public async Task<OrderDetailListModel> Handle(GetAllOrderDetailByCrewIdQuery request, CancellationToken cancellationToken)
            {
                await _orderDetailBusinessRules.CheckIfOrderDetailExistByCrewId(request.CrewId);

                var orderDetails = await _orderDetailRepository.GetListAsync(
                    x => x.CrewId == request.CrewId,
                    include:
                    x => x.Include(y => y.Payments),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                );

                _orderDetailBusinessRules.CheckIfOrderDetailListEmpty(orderDetails);

                var result = _mapper.Map<OrderDetailListModel>(orderDetails);

                return result;
            }
        }
    }
}
