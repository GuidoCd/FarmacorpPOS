using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;

namespace FarmacorpPOS.Infrastructure.Services
{
    public class ERPProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ERPProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RegisterNewProduct(string name, decimal cost, int stock, int productTypeId)
        {
            var uniqueCode = GenerateUniqueCode();
            var price = cost * 1.5m; // 50% margin

            var newExpressProduct = new ExpressProduct
            {
                Name = name,
                Price = price,
                IsActive = true,
                ExpirationDate = DateTime.Now.AddYears(1), // Placeholder value
                Observations = "",
                ProductTypeId = productTypeId
            };

            _unitOfWork.ExpressProducts.Add(newExpressProduct);
            _unitOfWork.Complete();

            var newErpProduct = new ErpProduct
            {
                Cost = cost,
                UniqueCode = uniqueCode,
                RegistrationDate = DateTime.Now,
                Stock = stock,
                ExpressProductId = newExpressProduct.Id
            };

            _unitOfWork.ErpProducts.Add(newErpProduct);
            _unitOfWork.Complete();
        }

        private string GenerateUniqueCode()
        {
            // Implement logic to generate a unique code
            return Guid.NewGuid().ToString();
        }
    }
}
