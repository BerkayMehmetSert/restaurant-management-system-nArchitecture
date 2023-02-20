using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Crews.Commands.CreateCrew;
using Project.Application.Features.Crews.Commands.DeleteCrew;
using Project.Application.Features.Crews.Commands.UpdateCrew;
using Project.Application.Features.Crews.Queries.GetAllCrew;
using Project.Application.Features.Crews.Queries.GetByIdCrew;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCrew([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllCrewQuery { PageRequest = pageRequest };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdCrew([FromQuery] GetByIdCrewQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCrew([FromBody] CreateCrewCommand command)
        {
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCrew([FromBody] UpdateCrewCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCrew([FromBody] DeleteCrewCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
