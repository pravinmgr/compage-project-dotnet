using MediatR;

namespace Procurement.Application.Commands.InvoiceService
{

    public class DeleteInvoiceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
