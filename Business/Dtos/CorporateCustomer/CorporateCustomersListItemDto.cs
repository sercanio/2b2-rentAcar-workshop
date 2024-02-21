namespace Business.Dtos.CorporateCustomer
{
    public class CorporateCustomersListItemDto
    {
        public int Id { get; set; }//
        // Şirketin adı
        public string CompanyName { get; set; }

        //Vergi numarası
        public string TaxNo { get; set; }

    }
}