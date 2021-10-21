using OrderProcessingEngine.Models;
using System.Collections.Generic;

namespace OrderProcessingEngine.BusinessLogic
{
    public interface IProductBusiness
    {
        List<ProductDetail> GetProductList();
    }
}
