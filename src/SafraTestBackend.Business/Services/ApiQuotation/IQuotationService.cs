using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Services.ApiQuotation
{
    public interface IQuotationService
    {
        Task<JObject> GetQuotationFinanceBySymbol(string symbol);
    }
}
