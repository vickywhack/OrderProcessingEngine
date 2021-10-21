using OrderProcessingEngine.BusinessLogic.PaymentProcessing;
using OrderProcessingEngine.Models;

namespace OrderProcessingEngine.BusinessLogic.PaymentProcessing.Factory
{
    public interface IPaymentFactory
    {
        IPaymentProcessing GetPaymentProcessingInstance(ProductType productType);
    }
}
