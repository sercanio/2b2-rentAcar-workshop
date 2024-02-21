using Core.Entities;

namespace Entities.Concrete
{
    public class DeleteCustomersRequest : Entity<int>
    {
        public int UserId { get; set; }

        public DeleteCustomersRequest()
        {

        }

        public DeleteCustomersRequest(int userId)
        {
            UserId = userId;
        }
    }
}
