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

namespace Project.Application.Features.Deliveries.Queries.GetAllDeliveryByOrderDetailId
{
    public class GetAllDeliveryByOrderDetailIdQuery : IRequest<DeliveryListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int OrderDetailId { get; set; }

        public class GetAllDeliveryByOrderDetailIdQueryHandler : IRequestHandler<GetAllDeliveryByOrderDetailIdQuery,
            DeliveryListModel>
        {
            private readonly IDeliveryRepository _deliveryRepository;
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public GetAllDeliveryByOrderDetailIdQueryHandler(IDeliveryRepository deliveryRepository,
                IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _deliveryRepository = deliveryRepository;
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<DeliveryListModel> Handle(GetAllDeliveryByOrderDetailIdQuery request, CancellationToken cancellationToken)
            {
                await _deliveryBusinessRules.CheckIfOrderDetailExist(request.OrderDetailId);

                var deliveries = await _deliveryRepository.GetListAsync(
                    x => x.OrderDetailId == request.OrderDetailId,
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
