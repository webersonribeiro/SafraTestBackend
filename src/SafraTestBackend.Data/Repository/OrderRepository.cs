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
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid Id)
        {
            return await _context.Orders.AsNoTracking()
                .Include(s => s.Stocks)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> ListOrdersBySymbolStocksAsync(string symbol)
        {
            return await _context.Orders.AsNoTracking()
                .Include(s => s.Stocks)
                .Where(p => p.Stocks.Symbol == symbol)
                .ToListAsync();
        }

        public async Task<Order> RegistryOrderAsync(Order order)
        {
            var orderEntity = _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return orderEntity.Entity;
        }
    }
}
