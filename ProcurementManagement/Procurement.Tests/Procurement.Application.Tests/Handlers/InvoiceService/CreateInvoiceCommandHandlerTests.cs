using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Handlers.InvoiceService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.InvoiceService
{
    public class CreateInvoiceCommandHandlerTests
    {
        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateInvoiceCommandHandler>> _logger;

        public CreateInvoiceCommandHandlerTests()
        {
            _invoiceRepository = new();
            _mapper = new();
            _logger = new();
        }



        [Fact]
        public async Task Handle_ReturnsInvoiceId()
        {
            // Arrange
            var request = new CreateInvoiceCommand(); // Create a request object as needed


            _mapper
                .Setup(m => m.Map<Invoice>(request))
                .Returns(new Invoice()); // Provide a mocked Invoice object


            _invoiceRepository
                .Setup(r => r.AddAsync(It.IsAny<Invoice>()))
                .ReturnsAsync(new Invoice { Id = 123 }); // Provide a mocked Invoice with an ID

            var loggerMock = new Mock<ILogger<CreateInvoiceCommandHandler>>();
            var handler = new CreateInvoiceCommandHandler(_invoiceRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); // Verify that the expected InvoiceId is returned
        }
    }
}
