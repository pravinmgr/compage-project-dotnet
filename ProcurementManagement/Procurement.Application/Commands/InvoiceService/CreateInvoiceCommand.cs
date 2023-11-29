using MediatR;

namespace Procurement.Application.Commands.InvoiceService
{
    public class CreateInvoiceCommand : IRequest<int>
    {
        public int Id { get; set; }
        /********************************************************/
        public string Name { get; set; }

    }
}
