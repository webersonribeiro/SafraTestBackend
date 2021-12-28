using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafraTestBackend.Domain.Entities
{
    public class Stocks : EntityBase
    {
        public Stocks(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;            
        }

        public string Symbol { get; set; }
        public string Name { get; set; }        
        public IEnumerable<Order> Orders { get; set; }
    }
}
