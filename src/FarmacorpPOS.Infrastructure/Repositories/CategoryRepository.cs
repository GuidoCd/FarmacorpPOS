using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
