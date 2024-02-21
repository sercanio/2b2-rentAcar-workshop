using Core.Entities;

namespace Entities.Concrete
{
    public class AddCustomersResponse : Entity<int>
    {
        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 

        public AddCustomersResponse()
        {

        }

        public AddCustomersResponse(int userId, string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
        }
    }
}
