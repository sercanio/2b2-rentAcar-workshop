using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        private readonly IUsersDal _usersDal;
        private readonly UsersBusinessRules _usersBusinessRules;
        private IMapper _mapper;

        public UsersManager(IUsersDal usersDal, UsersBusinessRules usersBusinessRules, IMapper mapper)
        {
            _usersDal = usersDal;
            _usersBusinessRules = usersBusinessRules;
            _mapper = mapper;
        }

        public AddUsersResponse Add(AddUsersRequest request)
        {//kullanıcının e-posta adresinin benzersiz olup olmadığını kontrol et
            _usersBusinessRules.CheckIfUserEmailExists(request.Email);

            Users userToAdd = _mapper.Map<Users>(request);

            _usersDal.Add(userToAdd);

            AddUsersResponse response = _mapper.Map<AddUsersResponse>(userToAdd);
            return response;
        }

        public DeleteUsersResponse Delete(DeleteUsersRequest request)
        {
            //silinecek kullanıcının ID'sini içeren nesneyi al
            Users? userToDelete = _usersDal.Get(predicate: user => user.Id == request.Id);
            _usersBusinessRules.CheckIfUserExists(userToDelete);
            //kullanıcının var olup olmadığını kontrol et
            Users deletedUser = _usersDal.Delete(userToDelete!);

            DeleteUsersResponse response = _mapper.Map<DeleteUsersResponse>(deletedUser);
            return response;
        }

        public GetUsersListResponse GetList(GetUsersListRequest request)
        {
            IList<Users> usersList = _usersDal.GetList();
            GetUsersListResponse response = _mapper.Map<GetUsersListResponse>(usersList);
            return response;
        }

        public UpdateUsersResponse Update(UpdateUsersRequest request)
        {
            Users? userToUpdate = _usersDal.Get(predicate: user => user.Id == request.Id);
            _usersBusinessRules.CheckIfUserExists(userToUpdate);

            userToUpdate = _mapper.Map(request, userToUpdate);
            Users updatedUser = _usersDal.Update(userToUpdate);

            var response = _mapper.Map<UpdateUsersResponse>(updatedUser);
            return response;
        }
    }
}
