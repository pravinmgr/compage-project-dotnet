using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Handlers.InvoiceService
{

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, ILogger<CreateInvoiceCommandHandler> logger)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Invoice>(request);
            var generatedOrder = await _invoiceRepository.AddAsync(orderEntity);
           _logger.LogInformation(" {generatedOrder} successfully created.", generatedOrder);
            return generatedOrder.Id;
        }
    }
}
