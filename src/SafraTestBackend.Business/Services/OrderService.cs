using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Services.ApiQuotation;
using SafraTestBackend.Business.Validations;
using SafraTestBackend.Domain.Entities;
using SafraTestBackend.Domain.Repository;
using System.Text.Json;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IQuotationService _quotationService;
        private readonly IStocksRepository _stocksRepository;
        public OrderService(IOrderRepository orderRepository,
            IQuotationService quotationService,
            IStocksRepository stocksRepository,
            INotificator notificator) : base(notificator)
        {
            _stocksRepository = stocksRepository;
            _orderRepository = orderRepository;
            _quotationService = quotationService;
        }

        public async Task RegistryOrderAsync(Order order)
        {
            var entityStocks = await _stocksRepository.GetById(order.StocksId);
            var objectQuotationFinance = await _quotationService.GetQuotationFinanceBySymbol(entityStocks.Symbol);

            if (!IsValidReturn(objectQuotationFinance))
            {
                Notify("Nenhum registro encontrado [Yahoo Finance]");
                return;
            }

            order.Price = GetRegularMarketPrice(objectQuotationFinance);

            if (!ExecuteValidation(new OrderValidation(), order)) return;
            await _orderRepository.RegistryOrderAsync(order);
        }

        private decimal GetRegularMarketPrice(JObject objectQuotationFinance)
        {
            dynamic valueJson = JsonConvert.DeserializeObject(objectQuotationFinance.ToString());
            return valueJson.quoteResponse.result[0].regularMarketPrice;
        }

        private bool IsValidReturn(JObject objectQuotationFinance)
        {
            dynamic valueJson = JsonConvert.DeserializeObject(objectQuotationFinance.ToString());
            return valueJson.quoteResponse.result.Count > 0 ? true : false; 
        }
    }
}
