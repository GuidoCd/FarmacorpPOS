using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class ExpressProductRepository : Repository<ExpressProduct>, IExpressProductRepository
    {
        public ExpressProductRepository(AppDbContext context) : base(context)
        {
        }

        public ExpressProduct Get(int productId)
        {
            return _context.Set<ExpressProduct>().FirstOrDefault(p => p.Id == productId);
        }
    }
}
