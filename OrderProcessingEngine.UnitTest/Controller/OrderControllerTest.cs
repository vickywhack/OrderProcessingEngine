using FakeItEasy;
using OrderProcessingEngine.BusinessLogic;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Concrete;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Factory;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing;
using OrderProcessingEngine.Controllers;
using OrderProcessingEngine.Data.IRepository;
using OrderProcessingEngine.Models;
using Xunit;

namespace OrderProcessingEngine.UnitTest.Controller
{
    [Collection("OrderControllerTest")]
    public class OrderControllerTest
    {
        [Fact]
        public void Calling_Order_Action_Method_Returns_View()
        {
            // Arrange
            var productBusiness = A.Fake<IProductBusiness>();
            var paymentFactory = A.Fake<IPaymentFactory>();
            OrdersController controller = new OrdersController(productBusiness, paymentFactory);
            // Act
            var result = controller.Orders();
            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(ProductType.Book)]
        [InlineData(ProductType.NewMemberShip)]
        [InlineData(ProductType.PhysicalProduct)]
        [InlineData(ProductType.UpgradeMembership)]
        [InlineData(ProductType.Video)]
        public void Calling_Process_ActionMethod_Calls_Other_Layers_Methods_And_return_View(ProductType productType)
        {
            // Arrange
            var productBusiness = A.Fake<IProductBusiness>();
            var paymentFactory = A.Fake<IPaymentFactory>();
            var productRepository = A.Fake<IProductRepository>();
            var paymentProcesser = A.Fake<IPaymentProcessing>();

            var instance = GetInstance(productType, productRepository);

            OrdersController controller = new OrdersController(productBusiness, paymentFactory);
            A.CallTo(() => paymentFactory.GetPaymentProcessingInstance(productType)).Returns(instance);
            A.CallTo(() => paymentProcesser.Process(1)).Returns("TestMessage");
            // Act
            var result = controller.Process(1, productType);
            // Assert
            Assert.NotNull(result);
            A.CallTo(() => paymentFactory.GetPaymentProcessingInstance(productType)).MustHaveHappened();

        }


        private IPaymentProcessing GetInstance(ProductType productType, IProductRepository productRepository)
        {
            switch (productType)
            {
                case ProductType.Book:
                    return new BookPaymentProcessing(productRepository);
                case ProductType.NewMemberShip:
                        return new NewMemberShipPaymentProcessing(productRepository);
                case ProductType.UpgradeMembership:
                    return new UpgradeMembershipPaymentProcessing(productRepository);
                case ProductType.Video:
                    return new VideoPaymentProcessing(productRepository);
                case ProductType.PhysicalProduct:
                    return new PhysicalProductPaymentProcessing(productRepository);
                default:
                    return null;
            }
        }
    }
}
