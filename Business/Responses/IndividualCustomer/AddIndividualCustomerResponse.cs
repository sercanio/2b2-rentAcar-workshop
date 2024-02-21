using Core.Entities;

namespace Entities.Concrete
{
    public class AddIndividualCustomerResponse : Entity<int>
    {
        public int Id { get; set; }//
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public AddIndividualCustomerResponse()
        {

        }

        public AddIndividualCustomerResponse(int id, string firstName, string lastName, string nationalIdentity)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
        }
    }
}
