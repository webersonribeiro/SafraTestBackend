using SafraTestBackend.Domain.Entities;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Interfaces
{
    public interface IStocksService
    {
        Task AddAsync(Stocks stocks);
    }
}
