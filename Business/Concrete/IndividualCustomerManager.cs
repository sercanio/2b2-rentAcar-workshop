using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Customers;
using Business.Responses.Customer;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
        private IMapper _mapper;

        public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal, IndividualCustomerBusinessRules individualCustomerBusinessRules, IMapper mapper)
        {
            _individualCustomerDal = individualCustomerDal;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
            _mapper = mapper;
        }

        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
        {
            IndividualCustomer individualCustomerToAdd = _mapper.Map<IndividualCustomer>(request);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerInfoValid(individualCustomerToAdd.FirstName);

            _individualCustomerDal.Add(individualCustomerToAdd);

            AddIndividualCustomerResponse response = _mapper.Map<AddIndividualCustomerResponse>(individualCustomerToAdd);
            return response;
        }

        public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request)
        {
            IList<IndividualCustomer> individualCustomersList = _individualCustomerDal.GetList();
            GetIndividualCustomerListResponse response = _mapper.Map<GetIndividualCustomerListResponse>(individualCustomersList);
            return response;
        }

        public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request)
        {
            IndividualCustomer? individualCustomerToUpdate = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToUpdate);

            individualCustomerToUpdate = _mapper.Map(request, individualCustomerToUpdate);
            IndividualCustomer updatedIndividualCustomer = _individualCustomerDal.Update(individualCustomerToUpdate!);

            var response = _mapper.Map<UpdateIndividualCustomerResponse>(updatedIndividualCustomer);
            return response;
        }

        public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request)
        {
            IndividualCustomer? individualCustomerToDelete = _individualCustomerDal.Get(predicate: individualCustomer => individualCustomer.Id == request.Id);
            _individualCustomerBusinessRules.CheckIfIndividualCustomerExists(individualCustomerToDelete);

            IndividualCustomer deletedIndividualCustomer = _individualCustomerDal.Delete(individualCustomerToDelete!);

            var response = _mapper.Map<DeleteIndividualCustomerResponse>(deletedIndividualCustomer);
            return response;
        }

        public GetIndividualCustomerListResponse GetOtherList(GetIndividualCustomerListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

