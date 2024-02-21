namespace Business.Requests.CorporateCustomer
{
    public class AddCorporateCustomerRequest
    {
        // Şirketin adı
        public string CompanyName { get; set; }

        //Vergi numarası
        public string TaxNo { get; set; }

        public AddCorporateCustomerRequest()
        {

        }
        public AddCorporateCustomerRequest(
        string companyName,
        string taxNo)

        {
            CompanyName = companyName;
            TaxNo = taxNo;
        }
    }
}