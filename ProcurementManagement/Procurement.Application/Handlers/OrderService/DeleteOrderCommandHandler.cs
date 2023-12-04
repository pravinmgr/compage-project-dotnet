using MediatR;
using Microsoft.Extensions.Logging;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Exceptions;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;


namespace Procurement.Application.Handlers.OrderService
{

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToDelete == null)
            {
                throw new OrderNotFoundException(nameof(Order), request.Id);
            }

            await _orderRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation("order with Id {request.Id} is deleted successfully.", request.Id);
        }
    }
}
