using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFuelDal : EfEntityRepositoryBase<Fuel, int, RentACarContext>, IFuelDal

    { //Add,Delete,Get,Getlist,Update 
        public EfFuelDal(RentACarContext context) : base(context)
        {
        }
    }
}
