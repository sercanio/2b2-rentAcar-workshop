namespace Business.Requests.CorporateCustomer
{
    public class AddCorporateCustomerResponse
    {
        // Şirketin adı
        public string CompanyName { get; set; }

        //Vergi numarası
        public string TaxNo { get; set; }

        public AddCorporateCustomerResponse()
        {

        }
        public AddCorporateCustomerResponse(
        string companyName,
        string taxNo)

        {
            CompanyName = companyName;
            TaxNo = taxNo;
        }
    }
}