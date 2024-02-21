using Core.Entities;

namespace Entities.Concrete
{   //FirstName, LastName, Email, Password
    public class Users : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public CorporateCustomer CorporateCustomer { get; set; }
        public Users()
        {
        }
        public Users(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
    //bir kullanıcı birden fazla müşteriye sahip olsun, müşteri türü (bireysel ya da kurumsal) sadece bir kullanıcıya ait olsun

    //Users nesnesi birden fazla Customers nesnesine sahip olabilir
    //public ICollection<Customers> Customers { get; set; } = new List<Customers>();//one-to-many

    // her bir Users nesnesi sadece bir IndividualCustomer nesnesine sahip olacak
    //public IndividualCustomer? IndividualCustomer { get; set; }

    // Her bir Users nesnesi sadece bir CorporateCustomer nesnesine sahip olacak
    // public CorporateCustomer CorporateCustomer { get; set; }
}
