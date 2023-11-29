using MediatR;
using Procurement.Application.Responses;

namespace Procurement.Application.Queries.InvoiceService
{

    public class GetInvoiceByIdQuery : IRequest<InvoiceResponse>
    {
        public int id { get; set; }

        public GetInvoiceByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
