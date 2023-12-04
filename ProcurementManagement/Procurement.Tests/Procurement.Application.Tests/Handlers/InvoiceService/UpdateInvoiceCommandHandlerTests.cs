using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Exceptions;
using Procurement.Application.Handlers.InvoiceService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.InvoiceService
{

    public class UpdateInvoiceCommandHandlerTests
    {
        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<ILogger<UpdateInvoiceCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateInvoiceCommandHandlerTests()
        {
            _invoiceRepository = new();
            _logger = new();
            _mapper = new();
        }




        [Fact]
        public async Task Handle_ThrowsOrderNotFoundExceptionWhenInvoiceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateInvoiceCommand { Id = Id }; // Create a request object

            _invoiceRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Invoice)null!); // Mock the repository to return null

            var handler = new UpdateInvoiceCommandHandler(_invoiceRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<OrderNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
