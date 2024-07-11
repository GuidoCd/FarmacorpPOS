using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;

namespace FarmacorpPOS.Infrastructure.Services
{
    public class ProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AssignCategoryToProduct(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId,
                CreationDate = DateTime.Now
            };

            _unitOfWork.ProductCategories.Add(productCategory);
            _unitOfWork.Complete();
        }
    }
}
