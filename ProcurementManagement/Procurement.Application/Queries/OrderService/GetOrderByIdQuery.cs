using MediatR;
using Procurement.Application.Responses;

namespace Procurement.Application.Queries.OrderService
{

    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public int id { get; set; }

        public GetOrderByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
