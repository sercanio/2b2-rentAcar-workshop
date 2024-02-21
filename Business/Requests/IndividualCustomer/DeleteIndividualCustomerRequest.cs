using Core.Entities;

namespace Entities.Concrete
{
    public class DeleteIndividualCustomerRequest : Entity<int>
    {
        public DeleteIndividualCustomerRequest()
        {

        }

        public DeleteIndividualCustomerRequest(int id)
        {
            Id = id;
        }
    }
}
