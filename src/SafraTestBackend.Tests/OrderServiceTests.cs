using Moq;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Services;
using SafraTestBackend.Business.Services.ApiQuotation;
using SafraTestBackend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafraTestBackend.Tests
{
    [Collection(nameof(OrderCollection))]
    public class OrderServiceTests
    {
        private readonly OrderTestsFixture _orderTestsFixture;

        public OrderServiceTests(OrderTestsFixture orderTestsFixture)
        {
            _orderTestsFixture = orderTestsFixture;
        }

        //[Fact]
        //public async Task Order_Service_RegistryOrderSucessfully()
        //{
        //    // Arrange
        //    var orderEntity = _orderTestsFixture.CreateValidOrder();
        //    var orderRepository = new Mock<IOrderRepository>();
        //    var quotatioService = new Mock<IQuotationService>();
        //    var notificator = new Mock<INotificator>();
        //    var orderService = new OrderService(orderRepository.Object, quotationService. ;

        //    // Act

        //    // Assert

        //}
    }
}
