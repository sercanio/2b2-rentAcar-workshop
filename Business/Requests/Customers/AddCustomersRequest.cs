using Core.Entities;

namespace Entities.Concrete
{
    public class AddCustomersRequest : Entity<int>
    {
        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 

       
        public AddCustomersRequest()
        {
          
        }

        public AddCustomersRequest(int userId, string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
        }
    }
}
