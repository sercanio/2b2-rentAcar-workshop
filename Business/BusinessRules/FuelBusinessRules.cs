using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        private readonly IFuelDal _fuelDal;

        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }
        //verilen (fuel) adının  veritabanında mevcut olup olmadığını kontrol et
        public void CheckIfFuelNameExists(string fuelName)
        {
            bool isExists = _fuelDal.GetList().Any(f => f.Name == fuelName);
            if (isExists)
            {
                throw new Exception("Fuel already exists.");
            }

        }
        //id değerine sahip (fuel) kaydının bulunup bulunmadığı kontrol et
        public Fuel FindFuelId(int id)
        {
            Fuel fuel = _fuelDal.GetList().SingleOrDefault(b => b.Id == id);
            return fuel;
        }
        //fuel nesnesinin null olup olmadoğını kontrol et
        public void CheckIfFuelExists(Fuel? fuel)
        {
            if (fuel is null)
                throw new NotFoundException("Fuel not found.");
        }
    }




}
