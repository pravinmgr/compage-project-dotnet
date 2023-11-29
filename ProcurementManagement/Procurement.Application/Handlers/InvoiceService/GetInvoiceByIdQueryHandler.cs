using AutoMapper;
using MediatR;
using Procurement.Application.Queries.InvoiceService;
using Procurement.Application.Responses;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.InvoiceService
{

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceResponse> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedOrder = await _invoiceRepository.GetByIdAsync(request.id);
            var orderEntity = _mapper.Map<InvoiceResponse>(generatedOrder);
            return orderEntity;
        }
    }
}
