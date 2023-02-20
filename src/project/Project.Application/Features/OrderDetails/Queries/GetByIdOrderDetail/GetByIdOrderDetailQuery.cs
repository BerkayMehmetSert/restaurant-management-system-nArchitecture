using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.OrderDetails.Dto;
using Project.Application.Features.OrderDetails.Rules;

namespace Project.Application.Features.OrderDetails.Queries.GetByIdOrderDetail
{
    public class GetByIdOrderDetailQuery : IRequest<OrderDetailDto>
    {
        public int Id { get; set; }

        public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQuery, OrderDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

            public GetByIdOrderDetailQueryHandler(IMapper mapper, OrderDetailBusinessRules orderDetailBusinessRules)
            {
                _mapper = mapper;
                _orderDetailBusinessRules = orderDetailBusinessRules;
            }

            public async Task<OrderDetailDto> Handle(GetByIdOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var orderDetail = await _orderDetailBusinessRules.CheckIfOrderDetailExistById(request.Id);
                
                var result = _mapper.Map<OrderDetailDto>(orderDetail);

                return result;
            }
        }
    }
}
