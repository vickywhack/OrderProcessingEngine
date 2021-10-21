using System;

namespace OrderProcessingEngine.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductName { get; set; }
        public ProductStatus Status { get; set; }
    }

    public enum ProductStatus
    {
        UnProcessed,
        Processed
    }

    public enum ProductType
    {
        PhysicalProduct,
        Book,
        NewMemberShip,
        UpgradeMembership,
        Video,
    }
}
