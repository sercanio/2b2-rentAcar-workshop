using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;

        public CorporateCustomerBusinessRules(ICorporateCustomerDal corporateCustomerDal)
        {
            _corporateCustomerDal = corporateCustomerDal;
        }

        // Verilen kurumsal müşteri bilgilerinin geçerli olup olmadığını kontrol et
        public void CheckIfCorporateCustomerInfoValid(string corporateCustomerInfo)
        {
            if (string.IsNullOrWhiteSpace(corporateCustomerInfo))
            {
                throw new BusinessException("Corporate customer info cannot be empty.");
            }
        }

        // Id değerine sahip kurumsal müşteri kaydının bulunup bulunmadığını kontrol et
        public CorporateCustomer FindCorporateCustomerId(int id)
        {
            CorporateCustomer corporateCustomer = _corporateCustomerDal.GetList().SingleOrDefault(cc => cc.Id == id);
            return corporateCustomer;
        }

        // Kurumsal müşteri nesnesinin null olup olmadığını kontrol et
        public void CheckIfCorporateCustomerExists(CorporateCustomer? corporateCustomer)
        {
            if (corporateCustomer is null)
            {
                throw new NotFoundException("Corporate customer not found.");
            }
        }
    }
}
