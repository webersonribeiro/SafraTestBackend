using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System;

namespace SafraTestBackend.Business.Services.ApiQuotation
{
    public class QuotationService : IQuotationService
    {
        private IConfiguration _configuration;
        public QuotationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<JObject> GetQuotationFinanceBySymbol(string symbol)
        {
            JObject result = new JObject();
            var api = _configuration.GetSection("ExternalApis").Get<ExternalApi>();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{ api.UrlBaseAddress }");
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", $"{ api.ApiKey }");
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await httpClient.GetAsync($"{ api.UrlParameters }{ symbol }");

            using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                result = JObject.Parse(await streamReader.ReadToEndAsync());
            }
            return result;            
        }
    }
}
