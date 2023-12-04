using AutoMapper;
using Moq;
using Procurement.Application.Handlers.OrderService;
using Procurement.Application.Queries.OrderService;
using Procurement.Application.Responses;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.OrderService
{
    public class GetOrderByIdQueryHandlerTests
    {

        [Fact]
        public async Task Handle_ReturnsOrderResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; // Replace with the ID of the order you want to retrieve
            var obj = new Order { Id = Id, /* other properties */ };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetOrderByIdQuery(Id);
            var handler = new GetOrderByIdQueryHandler(orderRepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            // Add assertions to check the mapping and properties of the OrderResponse
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
