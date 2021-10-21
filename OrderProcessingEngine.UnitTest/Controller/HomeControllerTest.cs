using OrderProcessingEngine.Controllers;
using Xunit;

namespace OrderProcessingEngine.UnitTest.Controller
{
    [Collection("HomeControllerTest")]
    public class HomeControllerTest
    {

        [Fact]
        public void Calling_Index_Returns_View()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            var result = controller.Index();
            // Assert
            Assert.NotNull(result);
        }

    }
}