using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Handlers.OrderService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.OrderService
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateOrderCommandHandler>> _logger;

        public CreateOrderCommandHandlerTests()
        {
            _orderRepository = new();
            _mapper = new();
            _logger = new();
        }



        [Fact]
        public async Task Handle_ReturnsOrderId()
        {
            // Arrange
            var request = new CreateOrderCommand(); // Create a request object as needed


            _mapper
                .Setup(m => m.Map<Order>(request))
                .Returns(new Order()); // Provide a mocked Order object


            _orderRepository
                .Setup(r => r.AddAsync(It.IsAny<Order>()))
                .ReturnsAsync(new Order { Id = 123 }); // Provide a mocked Order with an ID

            var loggerMock = new Mock<ILogger<CreateOrderCommandHandler>>();
            var handler = new CreateOrderCommandHandler(_orderRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); // Verify that the expected OrderId is returned
        }
    }
}
