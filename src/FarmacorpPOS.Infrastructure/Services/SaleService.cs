using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using System;
using System.Linq;

namespace FarmacorpPOS.Infrastructure.Services
{
    public class SaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RegisterSale(int productId, int quantity)
        {
            var product = _unitOfWork.ErpProducts.Get(productId);

            if (product == null || product.Stock < quantity)
            {
                throw new Exception("Product not available or insufficient stock.");
            }

            var discount = 0m;
            var productCategories = _unitOfWork.ProductCategories.Find(productId);
            if (productCategories.Count() == 1)
            {
                discount = 0.3m;
            }

            var expressProduct = _unitOfWork.ExpressProducts.Get(productId); // Obtener ExpressProduct asociado

            var sale = new ExpressSale
            {
                Date = DateTime.Now,
                Product = expressProduct, // Nombre del ExpressProduct
                UniqueProductCode = product.UniqueCode,
                Quantity = quantity,
                Price = expressProduct.Price, // Precio del ExpressProduct
                Discount = discount,
                Total = quantity * expressProduct.Price * (1 - discount), // Usar precio del ExpressProduct
                ProductId = productId
            };

            _unitOfWork.ExpressSales.Add(sale);
            product.Stock -= quantity;
            _unitOfWork.Complete();
        }
    }
}
