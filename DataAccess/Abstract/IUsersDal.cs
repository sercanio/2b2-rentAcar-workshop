using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<Users, int>
    {
      // IEntityRepository'den gelen genel CRUD operasyonları içerir.
    }
}
