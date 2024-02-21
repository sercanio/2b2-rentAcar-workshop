namespace Business.Responses.CorporateCustomer
{
    public class UpdateCorporateCustomerResponse
    {
        // Güncellenen kurumsal müşterinin ID'si
        public int UpdatedCorporateCustomerId { get; set; }

        // Yeni şirket adı
        public string NewCompanyName { get; set; }

        // Yeni vergi numarası
        public string NewTaxNo { get; set; }

        public UpdateCorporateCustomerResponse()
        {

        }

        public UpdateCorporateCustomerResponse(int updatedCorporateCustomerId, string newCompanyName, string newTaxNo)
        {
            UpdatedCorporateCustomerId = updatedCorporateCustomerId;
            NewCompanyName = newCompanyName;
            NewTaxNo = newTaxNo;
        }
    }
}
