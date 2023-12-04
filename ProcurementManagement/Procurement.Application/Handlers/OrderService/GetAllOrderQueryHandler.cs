using AutoMapper;
using MediatR;
using Procurement.Application.Queries.OrderService;
using Procurement.Application.Responses;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.OrderService
{

    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderResponse>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var generatedOrder = await _orderRepository.GetAllAsync();
            var orderEntity = _mapper.Map<List<OrderResponse>>(generatedOrder);
            return orderEntity;
        }

    }
}
