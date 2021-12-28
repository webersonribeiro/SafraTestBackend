using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafraTestBackend.Business.Services.ApiQuotation
{
    public class ExternalApi
    {
        public string UrlBaseAddress { get; set; }
        public string UrlParameters { get; set; }
        public string ApiKey { get; set; }
    }
}
