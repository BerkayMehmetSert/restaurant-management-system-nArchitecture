using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Menus.Commands.CreateMenu;
using Project.Application.Features.Menus.Commands.DeleteMenu;
using Project.Application.Features.Menus.Commands.UpdateMenu;
using Project.Application.Features.Menus.Queries.GetAllMenu;
using Project.Application.Features.Menus.Queries.GetAllMenuByFoodInfoId;
using Project.Application.Features.Menus.Queries.GetByIdMenu;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMenu([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllMenuQuery { PageRequest = pageRequest };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdMenu([FromQuery] GetByIdMenuQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyfoodid")]
        public async Task<IActionResult> GetByFoodIdMenu([FromQuery] PageRequest pageRequest, int foodId)
        {
            var query = new GetAllMenuByFoodInfoIdQuery { PageRequest = pageRequest, foodInfoId = foodId };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuCommand command)
        {
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] UpdateMenuCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenu([FromBody] DeleteMenuCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
