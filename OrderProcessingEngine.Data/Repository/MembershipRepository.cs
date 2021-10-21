using OrderProcessingEngine.Data.IRepository;

namespace OrderProcessingEngine.Data.Repository
{
    public class MembershipRepository : IMemberShipRepository
    {
        public string CreateNewMember(int productId)
        {
            return "Membership activated and an Email has been sent.";
        }
    }
}
