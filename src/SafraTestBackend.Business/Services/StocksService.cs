using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Validations;
using SafraTestBackend.Domain.Entities;
using SafraTestBackend.Domain.Repository;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Services
{
    public class StocksService : BaseService, IStocksService
    {
        private readonly IStocksRepository _stocksRepository;

        public StocksService(IStocksRepository stocksRepository,
            INotificator notificator) : base(notificator)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task AddAsync(Stocks stocks)
        {
            if (!ExecuteValidation(new StocksValidation(), stocks)) return;
            await _stocksRepository.AddAsync(stocks);
        }
    }
}
