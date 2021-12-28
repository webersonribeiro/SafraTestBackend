using SafraTestBackend.Domain.Enums;
using System;

namespace SafraTestBackend.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
            
        }
        public Order(decimal price, decimal quantity, decimal valueService, decimal taxValue, DateTime date, OrderType orderType, Guid stocksId) 
        {
            Price = price;
            Quantity = quantity;
            ValueService = valueService;
            TaxService = taxValue;
            Date = date;
            OrderType = orderType;
            StocksId = stocksId;
        }

        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalValue { get => CalculateValueOrder(); }
        public decimal ValueService  { get; set; }
        public decimal  TaxService { get; set; }
        public DateTime Date { get; set; }
        public OrderType OrderType { get; set; }
        public Guid StocksId{ get; set; }
        public Stocks Stocks { get; set; }

        private decimal CalculateValueOrder()
        {            
            var result = Price * Quantity;
            result += (result * TaxService) + ValueService;

            return result;
        }
    }
}
