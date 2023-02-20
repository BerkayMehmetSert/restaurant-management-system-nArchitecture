using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Payments.Commands.CreatePayment;
using Project.Application.Features.Payments.Queries.GetAllPayment;
using Project.Application.Features.Payments.Queries.GetAllPaymentByCustomerId;
using Project.Application.Features.Payments.Queries.GetByIdPayment;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetALlPayment([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllPaymentQuery { PageRequest = pageRequest };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdPayment([FromQuery] GetByIdPaymentQuery query)
        {
            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("customerId/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdPayment([FromQuery] PageRequest pageRequest, int customerId)
        {
            var query = new GetAllPaymentByCustomerIdQuery()
            {
                PageRequest = pageRequest,
                CustomerId = customerId
            };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            var result = await Mediator!.Send(command);

            return Created("", result);
        }
    }
}
