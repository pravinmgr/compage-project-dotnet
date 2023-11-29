using MediatR;
using Procurement.Application.Responses;

namespace Procurement.Application.Queries.InvoiceService
{

    public class GetAllInvoiceQuery : IRequest<List<InvoiceResponse>>
    {

    }
}
