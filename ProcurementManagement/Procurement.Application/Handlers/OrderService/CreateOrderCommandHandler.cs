using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Procurement.Application.Commands.OrderService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.OrderService
{

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var generatedOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation(" {generatedOrder} successfully created.", generatedOrder);
            return generatedOrder.Id;
        }
    }
}
