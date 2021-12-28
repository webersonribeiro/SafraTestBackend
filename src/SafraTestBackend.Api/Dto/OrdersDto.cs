using System;
using System.ComponentModel.DataAnnotations;

namespace SafraTestBackend.Api.Dto
{
    public class OrdersDto
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalValue { get => CalculateValueOrder(); }
        public decimal ValueService { get; set; }
        public decimal TaxService { get; set; }
        public DateTime Date { get; set; }
        public int OrderType { get; set; }
        public Guid StocksId { get; set; }

        [ScaffoldColumn(false)]
        public string StocksName { get; set; }
        
        private decimal CalculateValueOrder()
        {
            var result = Price * Quantity;
            result += (result * TaxService) + ValueService;

            return result;
        }
    }
}
