using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Exceptions;
using Procurement.Application.Handlers.OrderService;
using Procurement.Core.Entities;
using Procurement.Core.Repositories;

namespace Procurement.Application.Tests.Handlers.OrderService
{

    public class UpdateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ILogger<UpdateOrderCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateOrderCommandHandlerTests()
        {
            _orderRepository = new();
            _logger = new();
            _mapper = new();
        }




        [Fact]
        public async Task Handle_ThrowsOrderNotFoundExceptionWhenOrderNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateOrderCommand { Id = Id }; // Create a request object

            _orderRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Order)null); // Mock the repository to return null

            var handler = new UpdateOrderCommandHandler(_orderRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<OrderNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
