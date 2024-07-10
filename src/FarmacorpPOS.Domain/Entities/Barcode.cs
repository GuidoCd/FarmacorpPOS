namespace FarmacorpPOS.Domain.Entities
{
    public class Barcode
    {
        public int Id { get; set; }
        public string UniqueCode { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public ExpressProduct Product { get; set; }
    }
}
