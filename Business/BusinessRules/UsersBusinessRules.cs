using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class UsersBusinessRules
    {
        private readonly IUsersDal _usersDal;

        public UsersBusinessRules(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        // Verilen e-mail adresinin veritabanında mevcut olup olmadığını kontrol et
        public void CheckIfUserEmailExists(string email)
        {
            bool isExists = _usersDal.GetList().Any(u => u.Email == email);
            if (isExists)
            {
                throw new Exception("User email already exists.");
            }
        }

        // ID değerine sahip kullanıcı kaydının bulunup bulunmadığını kontrol et
        public Users FindUserId(int id)
        {
            Users user = _usersDal.GetList().SingleOrDefault(u => u.Id == id);
            return user;
        }

        // Kullanıcı nesnesinin null olup olmadığını kontrol et
        public void CheckIfUserExists(Users? users)
        {
            if (users is null)
                throw new NotFoundException("User not found.");
        }

       
    }
}
