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

namespace Project.Application.Features.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand : IRequest<DeletedDeliveryDto>
    {
        public int Id { get; set; }

        public class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand, DeletedDeliveryDto>
        {
            private readonly IDeliveryRepository _deliveryRepository;
            private readonly IMapper _mapper;
            private readonly DeliveryBusinessRules _deliveryBusinessRules;

            public DeleteDeliveryCommandHandler(IDeliveryRepository deliveryRepository,
                IMapper mapper, DeliveryBusinessRules deliveryBusinessRules)
            {
                _deliveryRepository = deliveryRepository;
                _mapper = mapper;
                _deliveryBusinessRules = deliveryBusinessRules;
            }

            public async Task<DeletedDeliveryDto> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
            {
                var delivery = await _deliveryBusinessRules.CheckIfDeliveryExists(request.Id);

                var delete = await _deliveryRepository.DeleteAsync(delivery);

                var result = _mapper.Map<DeletedDeliveryDto>(delete);

                return result;
            }
        }
    }
}
