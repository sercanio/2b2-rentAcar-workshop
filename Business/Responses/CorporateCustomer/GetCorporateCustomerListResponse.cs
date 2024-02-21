using Business.Dtos.CorporateCustomer;
using Business.Dtos.Customers;

namespace Business.Responses.Customers
{
    public class GetCorporateCustomerListResponse
    {
        public ICollection<CorporateCustomersListItemDto> Items { get; set; }

        public GetCorporateCustomerListResponse()
        {
            Items = Array.Empty<CorporateCustomersListItemDto>();
        }

        public GetCorporateCustomerListResponse(ICollection<CorporateCustomersListItemDto> items)
        {
            Items = items;
        }
    }
}
