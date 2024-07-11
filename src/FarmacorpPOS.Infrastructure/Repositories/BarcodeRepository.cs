using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class BarcodeRepository : Repository<Barcode>, IBarcodeRepository
    {
        public BarcodeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
