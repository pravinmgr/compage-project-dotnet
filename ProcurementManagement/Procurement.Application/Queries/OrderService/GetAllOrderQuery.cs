using MediatR;
using Procurement.Application.Responses;

namespace Procurement.Application.Queries.OrderService
{

    public class GetAllOrderQuery : IRequest<List<OrderResponse>>
    {

    }
}
