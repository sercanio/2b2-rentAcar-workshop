using AutoMapper;
using Business.Dtos.IndividualCustomer;
using Business.Responses.Customer;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class IndividualCustomerMapperProfiles : Profile
    {
        public IndividualCustomerMapperProfiles()
        {
            CreateMap<AddIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, AddIndividualCustomerResponse>();
            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
            CreateMap<DeleteIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerResponse>();
            CreateMap<IndividualCustomer, IndividualCustomerListItemDto>();
            CreateMap<IList<IndividualCustomer>, GetIndividualCustomerListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}
