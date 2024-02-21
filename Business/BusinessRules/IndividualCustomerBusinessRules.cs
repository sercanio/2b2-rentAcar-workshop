
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;

        public IndividualCustomerBusinessRules(IIndividualCustomerDal individualCustomerDal)
        {
            _individualCustomerDal = individualCustomerDal;
        }

        public void CheckIfIndividualCustomerInfoValid(string customerInfo)
        {
            if (string.IsNullOrWhiteSpace(customerInfo))
            {
                throw new BusinessException("Individual customer info cannot be empty.");
            }
        }

        public IndividualCustomer FindIndividualCustomerId(int id)
        {
            IndividualCustomer individualCustomer = _individualCustomerDal.GetList().SingleOrDefault(c => c.Id == id);
            return individualCustomer;
        }

        public void CheckIfIndividualCustomerExists(IndividualCustomer? individualCustomer)
        {
            if (individualCustomer is null)
            {
                throw new NotFoundException("Individual customer not found.");
            }
        }
    }
}
