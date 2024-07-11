using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class ErpProductRepository : Repository<ErpProduct>, IErpProductRepository
    {
        public ErpProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
