using OrderProcessingEngine.BusinessLogic.PaymentProcessing;
using OrderProcessingEngine.Data.IRepository;

namespace OrderProcessingEngine.BusinessLogic.PaymentProcessing.Concrete
{
    public class NewMemberShipPaymentProcessing : IPaymentProcessing
    {
        private readonly IProductRepository productRepository;
        public NewMemberShipPaymentProcessing( IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public string Process(int productId)
        {
            return productRepository.ProcessProductAndCreateMember(productId);
        }
    }
}
