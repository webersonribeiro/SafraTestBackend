using Moq;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Services;
using SafraTestBackend.Domain.Repository;
using System.Threading.Tasks;
using Xunit;

namespace SafraTestBackend.Tests
{
    [Collection(nameof(StocksCollection))]
    public class StocksServiceTests
    {
        private readonly StocksTestsFixture _stocksTestsFixture;

        public StocksServiceTests(StocksTestsFixture stocksTestsFixture)
        {
            _stocksTestsFixture = stocksTestsFixture;
        }

        [Fact]
        public async Task Stocks_Service_ExecutaComSucesso()
        {
            // Arrange
            var stocksEntity = _stocksTestsFixture.CreateValidStocks();            
            var stocksRepository = new Mock<IStocksRepository>();
            var notificator = new Mock<INotificator>();
            var stocksService = new StocksService(stocksRepository.Object, notificator.Object);

            // Act
            await stocksService.AddAsync(stocksEntity);

            // Assert            
            stocksRepository.Verify(r => r.AddAsync(stocksEntity), Times.Once);
            
        }

        [Fact]
        public async Task Stocks_Service_ExecutaComFalha()
        {
            // Arrange
            var stocksEntity = _stocksTestsFixture.CreateInvalidStocks();
            var stocksRepository = new Mock<IStocksRepository>();
            var notificator = new Mock<INotificator>();
            var stocksService = new StocksService(stocksRepository.Object, notificator.Object);

            // Act
            await stocksService.AddAsync(stocksEntity);

            // Assert            
            stocksRepository.Verify(r => r.AddAsync(stocksEntity), Times.Never);

        }
    }
}
