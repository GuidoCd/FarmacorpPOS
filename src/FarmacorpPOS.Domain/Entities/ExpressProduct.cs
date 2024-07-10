using System;

namespace FarmacorpPOS.Domain.Entities
{
    public class ExpressProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Remarks { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
