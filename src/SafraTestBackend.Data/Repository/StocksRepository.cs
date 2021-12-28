using Microsoft.EntityFrameworkCore;
using SafraTestBackend.Domain.Entities;
using SafraTestBackend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafraTestBackend.Data.Repository
{
    public class StocksRepository : IStocksRepository
    {
        private readonly Context _context;

        public StocksRepository(Context context)
        {
            _context = context;
        }

        public async Task<Stocks> AddAsync(Stocks stocks)
        {
            var stocksEntity = _context.Stocks.Add(stocks);
            await _context.SaveChangesAsync();
            return stocksEntity.Entity;
        }

        public async Task<IEnumerable<Stocks>> GetAllAsync()
        {
            return await _context.Stocks.AsNoTracking()
                .Include(x => x.Orders)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Stocks> GetById(Guid Id)
        {
            return await _context.Stocks.AsNoTracking()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
        }
    }
}
