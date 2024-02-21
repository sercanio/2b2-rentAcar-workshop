using Core.Entities;

namespace Entities.Concrete
{
    public class DeleteCustomersResponse : Entity<int>
    {

        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 

        public DeleteCustomersResponse()
        {

        }

        public DeleteCustomersResponse(int userId, string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
        }
    }
}
