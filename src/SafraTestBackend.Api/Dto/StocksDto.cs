using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafraTestBackend.Api.Dto
{
    public class StocksDto
    {
        [Key]
        public Guid Id { get; set; }        
        public string Symbol { get; set; }        
        public string Name { get; set; }
        public IEnumerable<OrdersDto> Orders { get; set; }
    }
}
