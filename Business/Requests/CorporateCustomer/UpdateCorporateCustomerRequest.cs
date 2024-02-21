namespace Business.Requests.CorporateCustomer
{
    public class UpdateCorporateCustomerRequest
    {
        // Güncellenecek kurumsal müşterinin ID'si
        public int CorporateCustomerId { get; set; }

        // Yeni şirket adı
        public string NewCompanyName { get; set; }

        // Yeni vergi numarası
        public string NewTaxNo { get; set; }

        public UpdateCorporateCustomerRequest()
        {

        }

        public UpdateCorporateCustomerRequest(int corporateCustomerId, string newCompanyName, string newTaxNo)
        {
            CorporateCustomerId = corporateCustomerId;
            NewCompanyName = newCompanyName;
            NewTaxNo = newTaxNo;
        }
    }
}
