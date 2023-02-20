using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.TransactionReports.Commands.CreateTransactionReport;
using Project.Application.Features.TransactionReports.Commands.DeleteTransactionReport;
using Project.Application.Features.TransactionReports.Queries.GetAllTransactionReport;
using Project.Application.Features.TransactionReports.Queries.GetByIdTransactionReport;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTransactionReport([FromQuery] PageRequest pageRequest)
        {
            var query = new GetALlTransactionReportQuery { PageRequest = pageRequest };

            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdTransactionReport([FromQuery] GetByIdTransactionReportQuery query)
        {
            var result = await Mediator!.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionReport([FromBody] CreateTransactionReportCommand command)
        {
            var result = await Mediator!.Send(command);

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransactionReport([FromQuery] DeleteTransactionReportCommand command)
        {
            var result = await Mediator!.Send(command);

            return Ok(result);
        }
    }
}
