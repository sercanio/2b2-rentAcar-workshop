using AutoMapper;
using Business.Dtos.Customers;
using Business.Responses.Customers;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CustomerMapperProfiles : Profile
    {
        public CustomerMapperProfiles()
        {
            CreateMap<AddCustomersRequest, Customers>();
            CreateMap<Customers, AddCustomersResponse>();
            CreateMap<UpdateCustomersRequest, Customers>();
            CreateMap<Customers, UpdateCustomersResponse>();
            CreateMap<DeleteCustomersRequest, Customers>();
            CreateMap<Customers, DeleteCustomersResponse>();
            CreateMap<Customers, CustomersListItemDto>();
            CreateMap<IList<Customers>, GetCustomersListResponse>().ForMember(destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src));
        }
    }
}
