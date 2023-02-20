using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.OrderDetails.Commands.CreateOrderDetail;
using Project.Application.Features.OrderDetails.Commands.DeleteOrderDetail;
using Project.Application.Features.OrderDetails.Commands.UpdateOrderDetail;
using Project.Application.Features.OrderDetails.Queries.GetAllOrderDetail;
using Project.Application.Features.OrderDetails.Queries.GetAllOrderDetailByCrewId;
using Project.Application.Features.OrderDetails.Queries.GetAllOrderDetailByCustomerId;
using Project.Application.Features.OrderDetails.Queries.GetAllOrderDetailByFoodInfoId;
using Project.Application.Features.OrderDetails.Queries.GetByIdOrderDetail;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllOrderDetailQuery { PageRequest = pageRequest };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("foodInfoId/{foodInfoId}")]
        public async Task<IActionResult> GetAllOrderDetailByFoodInfoId([FromQuery] PageRequest pageRequest,
            int foodInfoId)
        {
            var query = new GetAllOrderDetailByFoodInfoIdQuery { PageRequest = pageRequest, FoodInfoId = foodInfoId };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("customerId/{customerId}")]
        public async Task<IActionResult> GetAllOrderDetailByCustomerId([FromQuery] PageRequest pageRequest,
            int customerId)
        {
            var query = new GetAllOrderDetailByCustomerIdQuery { PageRequest = pageRequest, CustomerId = customerId };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("crewId/{crewId}")]
        public async Task<IActionResult> GetAllOrderDetailByCrewId([FromQuery] PageRequest pageRequest,
            int crewId)
        {
            var query = new GetAllOrderDetailByCrewIdQuery { PageRequest = pageRequest, CrewId = crewId };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdOrderDetail([FromQuery] GetByIdOrderDetailQuery query)
        {
            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand command)
        {
            var result = await Mediator!.Send(command);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailCommand command)
        {
            var result = await Mediator!.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail([FromQuery] DeleteOrderDetailCommand command)
        {
            var result = await Mediator!.Send(command);

            return Ok(result);
        }
    }
}
