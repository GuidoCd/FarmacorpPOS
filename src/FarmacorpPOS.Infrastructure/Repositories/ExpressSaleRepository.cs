using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class ExpressSaleRepository : Repository<ExpressSale>, IExpressSaleRepository
    {
        public ExpressSaleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
