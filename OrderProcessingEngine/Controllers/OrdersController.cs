using Microsoft.AspNetCore.Mvc;
using OrderProcessingEngine.BusinessLogic;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Factory;
using OrderProcessingEngine.Models;

namespace OrderProcessingEngine.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductBusiness productBusiness;
        private readonly IPaymentFactory paymentFactory;
        public OrdersController(IProductBusiness productBusiness, IPaymentFactory paymentFactory)
        {
            this.productBusiness = productBusiness;
            this.paymentFactory = paymentFactory;
        }
        // GET: OrdersController
        public ActionResult Orders()
        {
            return View("Orders", productBusiness.GetProductList());
        }

        public ActionResult Process(int productId, ProductType productType)
        {
            var paymentProcessor = paymentFactory.GetPaymentProcessingInstance(productType);
            var message = paymentProcessor.Process(productId);
            ViewBag.Message = message;
            return View("Confirmation");
        }
    }
}
