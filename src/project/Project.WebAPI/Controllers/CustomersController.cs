using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Customers.Commands.CreateCustomer;
using Project.Application.Features.Customers.Commands.DeleteCustomer;
using Project.Application.Features.Customers.Commands.UpdateCustomer;
using Project.Application.Features.Customers.Queries.GetAllCustomer;
using Project.Application.Features.Customers.Queries.GetByIdCustomer;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllCustomerQuery{ PageRequest = pageRequest };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetCustomerById([FromQuery] GetByIdCustomerQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromQuery] DeleteCustomerCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
