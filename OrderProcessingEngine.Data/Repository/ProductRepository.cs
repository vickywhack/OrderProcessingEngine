using OrderProcessingEngine.Data.IRepository;
using OrderProcessingEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessingEngine.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMemberShipRepository memberShipRepository;
        public ProductRepository(IMemberShipRepository memberShipRepository)
        {
            this.memberShipRepository = memberShipRepository;
        }

        public static List<ProductDetail> productDetailsList = new List<ProductDetail>
            {
            new ProductDetail {ProductId =1, ProductType =  ProductType.Book, ProductName = "JungleBook", Status = Status.UnProcessed},
            new ProductDetail {ProductId =2, ProductType =  ProductType.NewMemberShip, ProductName = "newMemberShip", Status = Status.UnProcessed },
            new ProductDetail {ProductId =3, ProductType =  ProductType.PhysicalProduct, ProductName = "PhisycalProduct", Status = Status.UnProcessed },
            new ProductDetail {ProductId =4, ProductType =  ProductType.UpgradeMembership, ProductName = "UpgradeMembers", Status = Status.UnProcessed },
            new ProductDetail {ProductId =5, ProductType =  ProductType.Video, ProductName = "Learning to Ski", Status = Status.UnProcessed }
            };
        public List<ProductDetail> GetProductList()
        {
            return productDetailsList;
        }

        public string ProcessProductAndCreateMember(int productId)
        {
            ChangeStatusToProcessed(productId);
            return memberShipRepository.CreateNewMember(productId);
        }

        // not calling repository for time constraints, just hard-coding the response from repository for other type of products
        public string ProcessProductAndCreateDuplicatePackingSlip(int productId)
        {
            ChangeStatusToProcessed(productId);
            return "Duplicate packing slip for the royalty department generated and commission has been added for Agent.";
        }

        public string ProcessProductAndGeneratePackingSlip(int productId)
        {
            ChangeStatusToProcessed(productId);
            return "Generated a packing slip for shipping and commission has been added for agent.";
        }

        public string ProcessProductAndUpgradeMemberShip(int productId)
        {
            ChangeStatusToProcessed(productId);
            return "Member ship upgraded, an email has been sent.";
        }

        public string ProcessProductAndAddFreeAidVideo(int productId)
        {
            ChangeStatusToProcessed(productId);
            return "Processed. check for Free Aid video in Packing slip.";
        }

        private void ChangeStatusToProcessed(int productId)
        {
            var product = productDetailsList.FirstOrDefault(x => x.ProductId == productId);
            product.Status = Status.Processed;
        }
    }
}
