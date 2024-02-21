using Business.Requests.CorporateCustomer;
using Business.Requests.Customers;
using Business.Responses.CorporateCustomer;
using Business.Responses.Customers;

namespace Business.Abstract
{
    public interface ICorporateCustomerService
    {
        AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request);
        UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request);
        DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request);
        GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request);
    }
}
