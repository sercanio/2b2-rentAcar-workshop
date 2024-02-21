
//using AutoMapper;
//using Business.Abstract;
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CorporateCustomer;
using Business.Requests.Customers;
using Business.Responses.CorporateCustomer;
using Business.Responses.Customers;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private IMapper _mapper;

        // Dependency injection ile bağımlılıkları enjekte et 
        public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IMapper mapper)
        {
            _corporateCustomerDal = corporateCustomerDal;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _mapper = mapper;
        }

        // Yeni kurumsal müşteri eklemek için
        public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
        {
            CorporateCustomer corporateCustomerToAdd = _mapper.Map<CorporateCustomer>(request);
            _corporateCustomerDal.Add(corporateCustomerToAdd);

            AddCorporateCustomerResponse response = _mapper.Map<AddCorporateCustomerResponse>(corporateCustomerToAdd);
            return response;
        }

        // Kurumsal müşteri listesini getirmek için
        public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request)
        {
            IList<CorporateCustomer> corporateCustomersList = _corporateCustomerDal.GetList();
            GetCorporateCustomerListResponse response = _mapper.Map<GetCorporateCustomerListResponse>(corporateCustomersList);
            return response;
        }

        // Kurumsal müşteriyi güncellemek için
        public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request)
        {
            CorporateCustomer? corporateCustomerToUpdate = _corporateCustomerDal.Get(predicate: cc => cc.Id == request.CorporateCustomerId);
            _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToUpdate);

            corporateCustomerToUpdate = _mapper.Map(request, corporateCustomerToUpdate);
            CorporateCustomer updatedCorporateCustomer = _corporateCustomerDal.Update(corporateCustomerToUpdate!);

            var response = _mapper.Map<UpdateCorporateCustomerResponse>(updatedCorporateCustomer);
            return response;
        }

        // Kurumsal müşteriyi silmek için
        public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
        {
            CorporateCustomer? corporateCustomerToDelete = _corporateCustomerDal.Get(predicate: cc => cc.Id == request.CorporateCustomerId);
            _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToDelete);

            CorporateCustomer deletedCorporateCustomer = _corporateCustomerDal.Delete(corporateCustomerToDelete!);

            var response = _mapper.Map<DeleteCorporateCustomerResponse>(deletedCorporateCustomer);
            return response;
        }

        public GetCorporateCustomerListResponse GetList(GetCustomersListResponse request)
        {
            throw new NotImplementedException();
        }

    }
}
