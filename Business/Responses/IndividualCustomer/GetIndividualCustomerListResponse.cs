using Business.Dtos.IndividualCustomer;
using System.Collections.Generic;

namespace Business.Responses.Customer
{
    public class GetIndividualCustomerListResponse
    {
        public ICollection<IndividualCustomerListItemDto> Items { get; set; }

        public GetIndividualCustomerListResponse()
        {
            Items = new List<IndividualCustomerListItemDto>();
        }

        public GetIndividualCustomerListResponse(ICollection<IndividualCustomerListItemDto> items)
        {
            Items = items;
        }
    }
}
