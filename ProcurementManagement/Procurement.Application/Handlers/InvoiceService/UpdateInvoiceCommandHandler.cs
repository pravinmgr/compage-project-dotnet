using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Exceptions;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;


namespace Procurement.Application.Handlers.InvoiceService
{

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateInvoiceCommandHandler> _logger;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, ILogger<UpdateInvoiceCommandHandler> logger)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _invoiceRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new OrderNotFoundException(nameof(Invoice), request.Id);
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateInvoiceCommand), typeof(Invoice));
            await _invoiceRepository.UpdateAsync(orderToUpdate);
            _logger.LogInformation("Order is successfully updated");
        }

    }

}
