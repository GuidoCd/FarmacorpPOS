using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces
{
    public interface IExpressProductRepository : IRepository<ExpressProduct>
    {
        ExpressProduct Get(int productId);
    }
}
