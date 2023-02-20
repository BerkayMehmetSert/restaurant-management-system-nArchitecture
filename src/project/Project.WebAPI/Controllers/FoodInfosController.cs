using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.FoodInfos.Commands.CreateFoodInfo;
using Project.Application.Features.FoodInfos.Commands.DeleteFoodInfo;
using Project.Application.Features.FoodInfos.Commands.UpdateFoodInfo;
using Project.Application.Features.FoodInfos.Queries.GetAllFoodInfo;
using Project.Application.Features.FoodInfos.Queries.GetByIdFoodInfo;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodInfosController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFoodInfo([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllFoodInfoQuery { PageRequest = pageRequest };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdFoodInfo([FromQuery] GetByIdFoodInfoQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodInfo([FromBody] CreateFoodInfoCommand command)
        {
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFoodInfo([FromBody] UpdateFoodInfoCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFoodInfo([FromBody] DeleteFoodInfoCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
