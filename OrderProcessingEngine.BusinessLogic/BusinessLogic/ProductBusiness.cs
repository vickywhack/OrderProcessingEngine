using OrderProcessingEngine.Models;
using System.Collections.Generic;
using OrderProcessingEngine.Data.IRepository;

namespace OrderProcessingEngine.BusinessLogic
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductDetail> GetProductList()
        {
             return productRepository.GetProductList();
        }
    }
}
