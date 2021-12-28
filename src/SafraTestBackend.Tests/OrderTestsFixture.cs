using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafraTestBackend.Tests
{
    [CollectionDefinition(nameof(OrderCollection))]
    public class OrderCollection : ICollectionFixture<OrderTestsFixture>
    {
    }

    public class OrderTestsFixture
    {
        public Order CreateValidOrder()
        {
            var entityOrder = new Order(
                    (decimal)0.1,
                    100,
                    (decimal)5.00,
                    (decimal)0.3222, 
                    DateTime.UtcNow, 
                    Domain.Enums.OrderType.Buy, 
                    Guid.NewGuid());

            return entityOrder;
        }
    }
}
