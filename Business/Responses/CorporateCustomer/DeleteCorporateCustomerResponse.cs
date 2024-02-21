namespace Business.Responses.CorporateCustomer
{
    public class DeleteCorporateCustomerResponse
    {
        // silinen kurumsal müşterinin ID'si 
        public int DeletedCorporateCustomerId { get; set; }

        public DeleteCorporateCustomerResponse()
        {

        }

        public DeleteCorporateCustomerResponse(int deletedCorporateCustomerId)
        {
            DeletedCorporateCustomerId = deletedCorporateCustomerId;
        }
    }
}
