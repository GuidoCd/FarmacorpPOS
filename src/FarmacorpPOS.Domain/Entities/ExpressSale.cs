using System;

namespace FarmacorpPOS.Domain.Entities
{
    public class ExpressSale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public string UniqueProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int ProductId { get; set; }
        public ExpressProduct Product { get; set; }
    }
}
