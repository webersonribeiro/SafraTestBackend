using SafraTestBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraTestBackend.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetById(Guid Id);
        Task<Order> RegistryOrderAsync(Order order);
        Task<IEnumerable<Order>> ListOrdersBySymbolStocks(string symbol);
    }
}
