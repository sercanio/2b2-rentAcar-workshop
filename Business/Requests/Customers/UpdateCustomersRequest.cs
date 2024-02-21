using Core.Entities;

namespace Entities.Concrete
{
    public class UpdateCustomersRequest : Entity<int>
    {
        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 

        public UpdateCustomersRequest()
        {

        }

        public UpdateCustomersRequest(int userId, string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
        }
    }
}
