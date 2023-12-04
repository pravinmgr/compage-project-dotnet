using MediatR;
using Microsoft.Extensions.Logging;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Exceptions;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;


namespace Procurement.Application.Handlers.InvoiceService
{

    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger<DeleteInvoiceCommandHandler> _logger;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, ILogger<DeleteInvoiceCommandHandler> logger)
        {
            _invoiceRepository = invoiceRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _invoiceRepository.GetByIdAsync(request.Id);
            if (orderToDelete == null)
            {
                throw new OrderNotFoundException(nameof(Invoice), request.Id);
            }

            await _invoiceRepository.DeleteAsync(orderToDelete);
            _logger.LogInformation("invoice with Id {request.Id} is deleted successfully.", request.Id);
        }
    }
}
