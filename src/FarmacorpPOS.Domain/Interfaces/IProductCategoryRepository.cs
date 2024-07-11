using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> Find(int productId);
    }
}
