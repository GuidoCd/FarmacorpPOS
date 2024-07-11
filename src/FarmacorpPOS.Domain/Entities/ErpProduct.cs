using System;

namespace FarmacorpPOS.Domain.Entities
{
    public class ErpProduct
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string UniqueCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Stock { get; set; }
        public ExpressProduct ExpressProduct { get; set; }
        public int ExpressProductId { get; set; }
    }
}
