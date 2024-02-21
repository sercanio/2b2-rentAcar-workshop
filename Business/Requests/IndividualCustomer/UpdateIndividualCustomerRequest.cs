using Core.Entities;

namespace Entities.Concrete
{
    public class UpdateIndividualCustomerRequest : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public UpdateIndividualCustomerRequest()
        {

        }

        public UpdateIndividualCustomerRequest(int id, string firstName, string lastName, string nationalIdentity)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
        }
    }
}
