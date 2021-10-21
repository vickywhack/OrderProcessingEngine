using OrderProcessingEngine.BusinessLogic.PaymentProcessing;
using OrderProcessingEngine.Data.IRepository;

namespace OrderProcessingEngine.BusinessLogic.PaymentProcessing.Concrete
{
    public class PhysicalProductPaymentProcessing : IPaymentProcessing
    {
        private readonly IProductRepository productRepository;
        public PhysicalProductPaymentProcessing(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public string Process(int productId)
        {
            return productRepository.ProcessProductAndGeneratePackingSlip(productId);
        }
    }
}
