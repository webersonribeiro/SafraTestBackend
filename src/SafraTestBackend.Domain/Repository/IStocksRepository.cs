using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraTestBackend.Domain.Repository
{
    public interface IStocksRepository
    {
        Task<IEnumerable<Stocks>> GetAllAsync();
        Task<Stocks> GetById(Guid Id);
        Task<Stocks> AddAsync(Stocks stocks);
    }
}
