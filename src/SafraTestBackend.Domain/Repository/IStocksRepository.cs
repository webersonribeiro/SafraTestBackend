using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraTestBackend.Domain.Repository
{
    public interface IStocksRepository
    {
        Task<IEnumerable<Stocks>> GetAllAsync();
        Task<Stocks> GetByIdAsync(Guid Id);
        Task<Stocks> GetBySymbolAsync(string symbol);
        Task<Stocks> AddAsync(Stocks stocks);
    }
}
