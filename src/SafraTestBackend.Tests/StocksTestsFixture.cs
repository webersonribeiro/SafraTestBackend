using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafraTestBackend.Tests
{
    [CollectionDefinition(nameof(StocksCollection))]
    public class StocksCollection : ICollectionFixture<StocksTestsFixture>
    {

    }
    public class StocksTestsFixture
    {
        public Stocks CreateValidStocks()
        {
            var stocksEntity = new Stocks(
                "PETR4",
                "Petrobras");

            return stocksEntity;
        }

        public Stocks CreateInvalidStocks()
        {
            var stocksEntity = new Stocks(
                "P",
                "Pet");

            return stocksEntity;
        }

    }
}
