using Microsoft.AspNetCore.Mvc;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Business.Services.ApiQuotation;

namespace SafraTestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : MainController
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService,
            INotificator notificator) : base(notificator)
        {
            _quotationService = quotationService;
        }

        [HttpGet]
        public string Get(string symbol)
        {
            var result = _quotationService.GetQuotationFinanceBySymbol(symbol);
            return result.Result.ToString();  
            
        }
    }
}
