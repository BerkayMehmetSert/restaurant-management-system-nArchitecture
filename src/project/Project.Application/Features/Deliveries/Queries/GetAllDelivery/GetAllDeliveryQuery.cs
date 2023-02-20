using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.Deliveries.Mapping;
using Project.Application.Features.Deliveries.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Deliveries.Queries.GetAllDelivery
{
    public class GetAllDeliveryQuery : IRequest<DeliveryListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllDeliveryQueryHandler : IRequestHandler<GetAllDeliveryQuery, DeliveryListModel>
        {
            private readonly IDeliveryRepository _deliveryRepository;
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public GetAllDeliveryQueryHandler(IDeliveryRepository deliveryRepository,
                IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _deliveryRepository = deliveryRepository;
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<DeliveryListModel> Handle(GetAllDeliveryQuery request, CancellationToken cancellationToken)
            {
                var deliveries = await _deliveryRepository.GetListAsync(
                    include:
                    x => x.Include(y => y.Payments),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page
                );

                _deliveryBusinessRules.CheckIfDeliveryListEmpty(deliveries);

                var result = _mapper.Map<DeliveryListModel>(deliveries);

                return result;
            }
        }
    }
}
