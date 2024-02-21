using Core.Entities;

namespace Entities.Concrete
{
    public class IndividualCustomer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
        // Her bir IndividualCustomer nesnesi sadece bir Users nesnesine sahip olacak
        // public Users User { get; set; }
        public IndividualCustomer()
        {

        }
        public IndividualCustomer(
         string firstName,
         string lastName,
         string nationalIdentity)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;

        }
    }
  
}
