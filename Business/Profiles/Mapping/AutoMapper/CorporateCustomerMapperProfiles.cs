using AutoMapper;
using Business.Dtos.CorporateCustomer;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Business.Responses.Customers;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CorporateCustomerMapperProfiles : Profile
    {
        public CorporateCustomerMapperProfiles()
        {
            CreateMap<AddCorporateCustomerRequest, CorporateCustomer>();
            CreateMap<CorporateCustomer, AddCorporateCustomerResponse>();
            CreateMap<UpdateCorporateCustomerRequest, CorporateCustomer>();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerResponse>();
            CreateMap<DeleteCorporateCustomerRequest, CorporateCustomer>();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerResponse>();
            CreateMap<CorporateCustomer, CorporateCustomersListItemDto>();
            CreateMap<IList<CorporateCustomer>, GetCorporateCustomerListResponse>().ForMember(dest => dest.Items,
                opt => opt.MapFrom(src => src));
        }
    }
}
