using FakeItEasy;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Concrete;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Factory;
using OrderProcessingEngine.Data.IRepository;
using OrderProcessingEngine.Models;
using Xunit;

namespace OrderProcessingApp.UnitTest.BusinessLogic.PaymentProcessing
{
    [Collection("PaymentFactoryTest")]
    public class PaymentFactoryTest
    {
        [Theory]
        [InlineData(ProductType.Book)]
        [InlineData(ProductType.NewMemberShip)]
        [InlineData(ProductType.PhysicalProduct)]
        [InlineData(ProductType.UpgradeMembership)]
        [InlineData(ProductType.Video)]
        public void Calling_GetPaymentProcessingInstance_Method_Returns_Correct_PaymentProcessing_Instance_Based_on_ProductType(ProductType productType)
        {
            // Arrange
            var productRepository = A.Fake<IProductRepository>();
            var paymentFactory = new BusinessPaymentProcessing(productRepository);

            // Act
            var result = paymentFactory.GetPaymentProcessingInstance(productType);

            // Assert
            Assert.NotNull(result);

            switch (productType)
            {
                case ProductType.Book:
                    Assert.True(result is BookPaymentProcessing);
                    break;
                case ProductType.NewMemberShip:
                    Assert.True(result is NewMemberShipPaymentProcessing);
                    break;
                case ProductType.UpgradeMembership:
                    Assert.True(result is UpgradeMembershipPaymentProcessing);
                    break;
                case ProductType.Video:
                    Assert.True(result is VideoPaymentProcessing);
                    break;
                case ProductType.PhysicalProduct:
                    Assert.True(result is PhysicalProductPaymentProcessing);
                    break;
            }
        }
    }
}
