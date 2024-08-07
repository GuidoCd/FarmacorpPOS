using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces
{
    public interface IErpProductRepository : IRepository<ErpProduct>
    {
        ErpProduct Get(int id);
    }
}
