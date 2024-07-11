using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;

namespace FarmacorpPOS.Infrastructure.Services
{
    public class BarcodeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BarcodeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AssignBarcode(int productId)
        {
            var uniqueCode = GenerateUniqueCode();

            var newBarcode = new Barcode
            {
                UniqueCode = uniqueCode,
                ProductId = productId,
                IsActive = true
            };

            _unitOfWork.Barcodes.Add(newBarcode);
            _unitOfWork.Complete();
        }

        private string GenerateUniqueCode()
        {
            // Implement logic to generate a unique code
            return Guid.NewGuid().ToString();
        }
    }
}
