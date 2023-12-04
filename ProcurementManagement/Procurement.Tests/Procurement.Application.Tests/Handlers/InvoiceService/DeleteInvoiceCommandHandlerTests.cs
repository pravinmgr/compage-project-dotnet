using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Exceptions;
using Procurement.Application.Handlers.InvoiceService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.InvoiceService
{

    public class DeleteInvoiceCommandHandlerTests
    {
        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<ILogger<DeleteInvoiceCommandHandler>> _logger;

        public DeleteInvoiceCommandHandlerTests()
        {
            _invoiceRepository = new();
            _logger = new();
        }


        [Fact]
        public async Task Handle_ThrowsOrderNotFoundExceptionWhenInvoiceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteInvoiceCommand { Id = Id }; // Create a request object

            _invoiceRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Invoice)null!); // Mock the repository to return null

            var handler = new DeleteInvoiceCommandHandler(_invoiceRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<OrderNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
