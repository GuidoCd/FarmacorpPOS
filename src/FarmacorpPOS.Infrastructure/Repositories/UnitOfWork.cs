using System.Threading.Tasks;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Data;

namespace FarmacorpPOS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            ProductTypes = new ProductTypeRepository(_context);
            ExpressProducts = new ExpressProductRepository(_context);
            ProductCategories = new ProductCategoryRepository(_context);
            ExpressSales = new ExpressSaleRepository(_context);
            ErpProducts = new ErpProductRepository(_context);
            Barcodes = new BarcodeRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }
        public IProductTypeRepository ProductTypes { get; private set; }
        public IExpressProductRepository ExpressProducts { get; private set; }
        public IProductCategoryRepository ProductCategories { get; private set; }
        public IExpressSaleRepository ExpressSales { get; private set; }
        public IErpProductRepository ErpProducts { get; private set; }
        public IBarcodeRepository Barcodes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
