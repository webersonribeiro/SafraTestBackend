using SafraTestBackend.Domain.Entities;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Interfaces
{
    public interface IOrderService
    {
        Task RegistryOrderAsync(Order order);
    }
}
