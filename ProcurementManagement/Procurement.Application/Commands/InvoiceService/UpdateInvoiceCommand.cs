using MediatR;

namespace Procurement.Application.Commands.InvoiceService
{

    public class UpdateInvoiceCommand : IRequest
    {
        public int Id { get; set; }
        /********************************************************/
        public string Name { get; set; }

    }
}
