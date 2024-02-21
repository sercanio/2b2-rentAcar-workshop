using AutoMapper;
using Business.Dtos.Users;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class UserMapperProfiles : Profile
    {
        public UserMapperProfiles()
        {
            CreateMap<AddUsersRequest, Users>();
            CreateMap<Users, AddUsersResponse>();
            CreateMap<UpdateUsersRequest, Users>();
            CreateMap<Users, UpdateUsersResponse>();
            CreateMap<DeleteUsersRequest, Users>();
            CreateMap<Users, DeleteUsersResponse>();

            CreateMap<Users, UsersListItemDto>();
            CreateMap<IList<Users>, GetUsersListResponse>()
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src));
        }
    }
}
