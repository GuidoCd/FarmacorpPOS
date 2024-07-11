using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ProductCategory> Find(int productId)
        {
            return _context.Set<ProductCategory>().Where(pc => pc.ProductId == productId).ToList();
        }
    }
}
