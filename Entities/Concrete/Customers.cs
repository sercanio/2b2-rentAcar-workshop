using Core.Entities;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class Customers : Entity<int>
    {
        public int UserId { get; set; }
        public string CustomerInfo { get; set; } // Müşteri bilgileri 
        //   public Users User { get; set; }
        public Customers()
        {

        }
        public Customers(
          int userId,
          string customerInfo)
        {
            UserId = userId;
            CustomerInfo = customerInfo;
         
        }
    }
}
