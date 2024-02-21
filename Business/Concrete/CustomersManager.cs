using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Customers;
using Business.Responses.Customers;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService
    {
        private readonly ICustomersDal _customersDal;
        private readonly CustomersBusinessRules _customersBusinessRules;
        private IMapper _mapper;

        public CustomersManager(ICustomersDal customersDal, CustomersBusinessRules customersBusinessRules, IMapper mapper)
        {
            _customersDal = customersDal;
            _customersBusinessRules = customersBusinessRules;
            _mapper = mapper;
        }

        public AddCustomersResponse Add(AddCustomersRequest request)
        {
            Customers customersToAdd = _mapper.Map<Customers>(request);
            _customersDal.Add(customersToAdd);

            AddCustomersResponse response = _mapper.Map<AddCustomersResponse>(customersToAdd);
            return response;
        }

        public GetCustomersListResponse GetList(GetCustomersListRequest request)
        {
            IList<Customers> customersList = _customersDal.GetList();
            GetCustomersListResponse response = _mapper.Map<GetCustomersListResponse>(customersList);
            return response;
        }

        public UpdateCustomersResponse Update(UpdateCustomersRequest request)
        {
            Customers? customersToUpdate = _customersDal.Get(predicate: customers => customers.Id == request.Id);
            _customersBusinessRules.CheckIfCustomersExists(customersToUpdate);

            customersToUpdate = _mapper.Map(request, customersToUpdate);
            Customers updatedCustomers = _customersDal.Update(customersToUpdate!);

            var response = _mapper.Map<UpdateCustomersResponse>(updatedCustomers);
            return response;
        }

        public DeleteCustomersResponse Delete(DeleteCustomersRequest request)
        {
            Customers? customersToDelete = _customersDal.Get(predicate: customers => customers.Id == request.Id);
            _customersBusinessRules.CheckIfCustomersExists(customersToDelete);

            Customers deletedCustomers = _customersDal.Delete(customersToDelete!);

            var response = _mapper.Map<DeleteCustomersResponse>(deletedCustomers);
            return response;
        }
    }
}
