using AutoMapper;
using MediatR;
using Procurement.Application.Queries.InvoiceService;
using Procurement.Application.Responses;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.InvoiceService
{

    public class GetAllInvoiceQueryHandler : IRequestHandler<GetAllInvoiceQuery, List<InvoiceResponse>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public GetAllInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<List<InvoiceResponse>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            var generatedOrder = await _invoiceRepository.GetAllAsync();
            var orderEntity = _mapper.Map<List<InvoiceResponse>>(generatedOrder);
            return orderEntity;
        }

    }
}
