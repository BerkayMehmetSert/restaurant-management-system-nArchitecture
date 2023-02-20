using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Deliveries.Commands.CreateDelivery;
using Project.Application.Features.Deliveries.Commands.DeleteDelivery;
using Project.Application.Features.Deliveries.Commands.UpdateDelivery;
using Project.Application.Features.Deliveries.Queries.GetAllDelivery;
using Project.Application.Features.Deliveries.Queries.GetAllDeliveryByOrderDetailId;
using Project.Application.Features.Deliveries.Queries.GetByIdDelivery;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDelivery([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllDeliveryQuery { PageRequest = pageRequest };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("orderDetailId/{orderDetailId}")]
        public async Task<IActionResult> GetAllDeliveryByOrderDetailId([FromQuery] PageRequest pageRequest,
            int orderDetailId)
        {
            var query = new GetAllDeliveryByOrderDetailIdQuery
            {
                PageRequest = pageRequest,
                OrderDetailId = orderDetailId
            };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdDelivery([FromQuery] GetByIdDeliveryQuery query)
        {
            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] CreateDeliveryCommand command)
        {
            var result = await Mediator!.Send(command);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDelivery([FromBody] UpdateDeliveryCommand command)
        {
            var result = await Mediator!.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDelivery([FromQuery] DeleteDeliveryCommand command)
        {
            var result = await Mediator!.Send(command);

            return Ok(result);
        }
    }
}
