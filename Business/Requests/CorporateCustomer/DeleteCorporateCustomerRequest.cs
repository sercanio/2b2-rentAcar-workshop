namespace Business.Requests.CorporateCustomer
{
    public class DeleteCorporateCustomerRequest
    {
        // silinecek kurumsal müşterinin ID'si
        public int CorporateCustomerId { get; set; }

        public DeleteCorporateCustomerRequest()
        {

        }

        public DeleteCorporateCustomerRequest(int corporateCustomerId)
        {
            CorporateCustomerId = corporateCustomerId;
        }
    }
}
