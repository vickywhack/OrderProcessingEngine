using FakeItEasy;
using OrderProcessingEngine.BusinessLogic;
using OrderProcessingEngine.Data.IRepository;
using OrderProcessingEngine.Models;
using System.Collections.Generic;
using Xunit;

namespace OrderProcessingApp.UnitTest.BusinessLogic
{
    [Collection("ProductBusinessTest")]
    public class ProductBusinessTest
    {
        [Fact]
        public void Calling_GetProductList__Method_Returns_ListOfProductDetails()
        {
            // Arrange
            var productRepository = A.Fake<IProductRepository>();
            var listOfProductDetails = new List<ProductDetail>() { new ProductDetail { ProductId = 1 } };
            var productBusiness = new ProductBusiness(productRepository);
            A.CallTo(() => productRepository.GetProductList()).Returns(listOfProductDetails);

            // Act
            var result = productRepository.GetProductList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(listOfProductDetails.Count, result.Count);
            A.CallTo(() => productRepository.GetProductList()).MustHaveHappened();

        }

    }
}
