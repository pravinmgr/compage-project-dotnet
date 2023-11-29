using MediatR;
using Microsoft.AspNetCore.Mvc;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Queries.InvoiceService;
using Procurement.Application.Responses;
using System.Net;


namespace ProcurementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InvoiceServiceController> _logger;
        public InvoiceServiceController(IMediator mediator, ILogger<InvoiceServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllInvoice")]
        [ProducesResponseType(typeof(IEnumerable<List<InvoiceResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<InvoiceResponse>>> GetAllInvoice(CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetAllInvoiceQuery(), cancellationToken);
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetInvoiceById")]
        [ProducesResponseType(typeof(InvoiceResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<InvoiceResponse>> GetInvoiceById(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetInvoiceByIdQuery(id), cancellationToken);
            return Ok(response);
        }


        [HttpPost(Name = "CreateInvoice")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteInvoice(int id)
        {
            var cmd = new DeleteInvoiceCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }

    }
}
