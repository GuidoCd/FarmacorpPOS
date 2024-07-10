using System;

namespace FarmacorpPOS.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProductId { get; set; }
        public ExpressProduct Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
