using AutoMapper;
using Moq;
using Procurement.Application.Handlers.InvoiceService;
using Procurement.Application.Queries.InvoiceService;
using Procurement.Application.Responses;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.InvoiceService
{
    public class GetInvoiceByIdQueryHandlerTests
    {

        [Fact]
        public async Task Handle_ReturnsInvoiceResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; // Replace with the ID of the invoice you want to retrieve
            var obj = new Invoice { Id = Id, /* other properties */ };

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetInvoiceByIdQuery(Id);
            var handler = new GetInvoiceByIdQueryHandler(invoiceRepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InvoiceResponse>(result);
            // Add assertions to check the mapping and properties of the InvoiceResponse
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
