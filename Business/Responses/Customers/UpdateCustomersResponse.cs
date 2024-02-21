using Core.Entities;

namespace Entities.Concrete
{
    public class UpdateCustomersResponse : Entity<int>
    {
        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 

        public UpdateCustomersResponse()
        {

        }

        public UpdateCustomersResponse(int userId, string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
        }
    }
}
