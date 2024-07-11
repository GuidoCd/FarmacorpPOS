using System;
using System.Threading.Tasks;

namespace FarmacorpPOS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductTypeRepository ProductTypes { get; }
        IExpressProductRepository ExpressProducts { get; }
        IProductCategoryRepository ProductCategories { get; }
        IExpressSaleRepository ExpressSales { get; }
        IErpProductRepository ErpProducts { get; }
        IBarcodeRepository Barcodes { get; }
        Task<int> CompleteAsync();
    }
}
