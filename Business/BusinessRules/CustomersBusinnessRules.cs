using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class CustomersBusinessRules
    {
        private readonly ICustomersDal _customersDal;

        public CustomersBusinessRules(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        // Verilen müşteri bilgilerinin  geçerli olup olmadığını kontrol et
        public void CheckIfCustomersInfoValid(string customersInfo)
        {
          
            if (string.IsNullOrWhiteSpace(customersInfo))
            {
                throw new BusinessException("Customer info cannot be empty.");
            }
        }

        // Id değerine sahip müşteri kaydının bulunup bulunmadığını kontrol et
        public Customers FindCustomersId(int id)
        {
            Customers customers = _customersDal.GetList().SingleOrDefault(c => c.Id == id);
            return customers;
        }

        // Müşteri nesnesinin null olup olmadığını kontrol et
        public void CheckIfCustomersExists(Customers? customers)
        {
            if (customers is null)
            {
                throw new NotFoundException("Customer not found.");
            }
        }
    }
}
