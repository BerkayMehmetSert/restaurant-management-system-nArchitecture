using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Deliveries.Dto;
using Project.Application.Features.Deliveries.Rules;

namespace Project.Application.Features.Deliveries.Queries.GetByIdDelivery
{
    public class GetByIdDeliveryQuery : IRequest<DeliveryDto>
    {
        public int Id { get; set; }

        public class GetByIdDeliveryQueryHandler : IRequestHandler<GetByIdDeliveryQuery, DeliveryDto>
        {
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public GetByIdDeliveryQueryHandler(IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<DeliveryDto> Handle(GetByIdDeliveryQuery request, CancellationToken cancellationToken)
            {
                var delivery = await _deliveryBusinessRules.CheckIfDeliveryExists(request.Id);

                var result = _mapper.Map<DeliveryDto>(delivery);

                return result;
            }
        }
    }
}
