using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Deliveries.Dto;
using Project.Application.Features.Deliveries.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommand : IRequest<CreatedDeliveryDto>
    {
        public int OrderDetailId { get; set; }

        public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, CreatedDeliveryDto>
        {
            private readonly IDeliveryRepository _deliveryRepository;
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository, IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _deliveryRepository = deliveryRepository;
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<CreatedDeliveryDto> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
            {
                await _deliveryBusinessRules.CheckIfOrderDetailExist(request.OrderDetailId);

                var requestToEntity = _mapper.Map<Delivery>(request);

                var create = await _deliveryRepository.AddAsync(requestToEntity);

                var result = _mapper.Map<CreatedDeliveryDto>(create);

                return result;
            }
        }
    }
}
