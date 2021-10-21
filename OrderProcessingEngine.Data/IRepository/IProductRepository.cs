using OrderProcessingEngine.Models;
using System.Collections.Generic;

namespace OrderProcessingEngine.Data.IRepository
{
    public interface IProductRepository
    {
        List<ProductDetail> GetProductList();
        string ProcessProductAndCreateMember(int productId);
        string ProcessProductAndCreateDuplicatePackingSlip(int productId);
        string ProcessProductAndGeneratePackingSlip(int productId);
        string ProcessProductAndUpgradeMemberShip(int productId);
        string ProcessProductAndAddFreeAidVideo(int productId);
    }
}
