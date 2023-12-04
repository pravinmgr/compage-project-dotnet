using MediatR;

namespace Procurement.Application.Commands.OrderService
{

    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
