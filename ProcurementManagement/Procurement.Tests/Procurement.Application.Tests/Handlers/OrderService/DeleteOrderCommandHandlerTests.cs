using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Exceptions;
using Procurement.Application.Handlers.OrderService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.OrderService
{

    public class DeleteOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<DeleteOrderCommandHandler>> _logger;

        public DeleteOrderCommandHandlerTests()
        {
            _orderRepository = new();
            _logger = new();
        }


        [Fact]
        public async Task Handle_ThrowsOrderNotFoundExceptionWhenOrderNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteOrderCommand { Id = Id }; // Create a request object

            _orderRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Order)null); // Mock the repository to return null

            var handler = new DeleteOrderCommandHandler(_orderRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<OrderNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
