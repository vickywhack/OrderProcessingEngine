using FakeItEasy;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Concrete;
using OrderProcessingEngine.BusinessLogic.PaymentProcessing.Factory;
using OrderProcessingEngine.Data.IRepository;
using OrderProcessingEngine.Models;
using Xunit;

namespace OrderProcessingApp.UnitTest.BusinessLogic.PaymentProcessing
{
    [Collection("BookPaymentProcessingTest")]
    public class BookPaymentProcessingTest
    {
        [Fact]
        public void Calling_Process_For_Book_Payment_Processing_Calls_Product_Repository_And_Returns_Response()
        {

            // Arrange
            var productRepository = A.Fake<IProductRepository>();
            var bookPaymentProcessing = new BookPaymentProcessing(productRepository);
            var message = "Duplicate packing slip for the royalty department generated and commission has been added for Agent.";

            A.CallTo(() => productRepository.ProcessProductAndCreateDuplicatePackingSlip(1)).Returns(message);

            // Act
            var result = bookPaymentProcessing.Process(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(message, result);
            A.CallTo(() => productRepository.ProcessProductAndCreateDuplicatePackingSlip(1)).MustHaveHappened();
        }
    }
}
