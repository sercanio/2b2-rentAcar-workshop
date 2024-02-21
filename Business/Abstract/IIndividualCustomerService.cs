using Business.Requests.Customers;
using Business.Responses.Customer;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IIndividualCustomerService
    {
        AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request);
        UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request);
        DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request);
        GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request);
    }
}
