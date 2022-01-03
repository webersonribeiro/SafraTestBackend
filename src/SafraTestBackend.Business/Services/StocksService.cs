using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Validations;
using SafraTestBackend.Domain.Entities;
using SafraTestBackend.Domain.Repository;
using System;
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
            if (await ExistsWithSymbol(stocks.Symbol))
            {
                Notify("Já existe um cadastro com o mesmo simbolo");
                return;
            }

            if (await ExistsWithGuid(stocks.Id))
            {
                Notify("Já existe um cadastro com o mesmo ID");
                return;
            }

            if (!ExecuteValidation(new StocksValidation(), stocks)) return;
            await _stocksRepository.AddAsync(stocks);
        }

        private async Task<bool> ExistsWithSymbol(string symbol)
        {
            return await _stocksRepository.GetBySymbolAsync(symbol) == null ? false : true;
        }

        private async Task<bool> ExistsWithGuid(Guid Id)
        {
            return await _stocksRepository.GetByIdAsync(Id) == null ? false : true;
        }
    }
}
