using Core.Entities;

namespace Entities.Concrete
{
    public class UpdateIndividualCustomerResponse : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public UpdateIndividualCustomerResponse()
        {

        }

        public UpdateIndividualCustomerResponse(int id, string firstName, string lastName, string nationalIdentity)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
        }
    }
}
