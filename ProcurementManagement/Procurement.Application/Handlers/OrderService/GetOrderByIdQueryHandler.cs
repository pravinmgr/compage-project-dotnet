using AutoMapper;
using MediatR;
using Procurement.Application.Queries.OrderService;
using Procurement.Application.Responses;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.OrderService
{

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedOrder = await _orderRepository.GetByIdAsync(request.id);
            var orderEntity = _mapper.Map<OrderResponse>(generatedOrder);
            return orderEntity;
        }
    }
}
