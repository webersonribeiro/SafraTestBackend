using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraTestBackend.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid Id);
        Task<Order> RegistryOrderAsync(Order order);
        Task<IEnumerable<Order>> ListOrdersBySymbolStocksAsync(string symbol);
    }
}
