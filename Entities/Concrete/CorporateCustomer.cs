using Core.Entities;


namespace Entities.Concrete
{
    public class CorporateCustomer : Entity<int>
    {
        // Şirketin adı
        public string CompanyName { get; set; }

        //Vergi numarası
       public string TaxNo { get; set; }

        // Her bir CorporateCustomer nesnesi sadece bir Users nesnesine sahip olacak
        // public Users User { get; set; }

        public CorporateCustomer()
         {
         }
        public CorporateCustomer(
        string companyName,
        string taxNo)

        {
            CompanyName = companyName;
            TaxNo = taxNo;
        }
    }
}