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

namespace Project.Application.Features.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand : IRequest<UpdatedDeliveryDto>
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }

        public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand, UpdatedDeliveryDto>
        {
            private readonly IDeliveryRepository _deliveryRepository;
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public UpdateDeliveryCommandHandler(IDeliveryRepository deliveryRepository,
                IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _deliveryRepository = deliveryRepository;
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<UpdatedDeliveryDto> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
            {
                await _deliveryBusinessRules.CheckIfOrderDetailExist(request.OrderDetailId);
                var delivery = await _deliveryBusinessRules.CheckIfDeliveryExists(request.Id);

                var update = await _deliveryRepository.UpdateAsync(delivery);

                var result = _mapper.Map<UpdatedDeliveryDto>(update);

                return result;
            }
        }
    }
}
