using AutoMapper;
using Moq;
using Procurement.Application.Handlers.OrderService;
using Procurement.Application.Queries.OrderService;
using Procurement.Application.Responses;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.OrderService
{
    public class GetAllOrderQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfOrderResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var orders = new List<Order> // Create a list of orders for testing
        {
            new Order { Id = 1, Name="Order 1" ,Description="Desc 1", Price=2400,Quantity=120 },
            new Order { Id = 2, Name="Order 2" ,Description="Desc 2", Price=400,Quantity=30}

        };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(orders);

            var query = new GetAllOrderQuery();
            var handler = new GetAllOrderQueryHandler(orderRepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<OrderResponse>>(result);
            Assert.Equal(orders.Count, result.Count);
            // You can add more assertions to check the mapping and properties of OrderResponse objects
        }
    }
}
