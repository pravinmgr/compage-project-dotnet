using MediatR;
using Microsoft.AspNetCore.Mvc;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Queries.OrderService;
using Procurement.Application.Responses;
using System.Net;


namespace ProcurementManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderServiceController> _logger;
        public OrderServiceController(IMediator mediator, ILogger<OrderServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllOrder")]
        [ProducesResponseType(typeof(IEnumerable<List<OrderResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrder(CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetAllOrderQuery(), cancellationToken);
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrderById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Order GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
            return Ok(response);
        }


        [HttpPost(Name = "CreateOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            _logger.LogInformation("Order DELETE request received for ID {id}", id);
            var cmd = new DeleteOrderCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }

    }
}
