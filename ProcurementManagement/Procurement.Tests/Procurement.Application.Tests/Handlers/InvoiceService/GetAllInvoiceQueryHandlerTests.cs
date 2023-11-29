using AutoMapper;
using Moq;
using Procurement.Application.Handlers.InvoiceService;
using Procurement.Application.Queries.InvoiceService;
using Procurement.Application.Responses;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.InvoiceService
{
    public class GetAllInvoiceQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfInvoiceResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var invoices = new List<Invoice> // Create a list of invoices for testing
        {
            new Invoice { Id = 1, Name="Test 1" },
            new Invoice { Id = 2, Name="Test 2" }

        };

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(invoices);

            var query = new GetAllInvoiceQuery();
            var handler = new GetAllInvoiceQueryHandler(invoiceRepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<InvoiceResponse>>(result);
            Assert.Equal(invoices.Count, result.Count);
            // You can add more assertions to check the mapping and properties of InvoiceResponse objects
        }
    }
}
