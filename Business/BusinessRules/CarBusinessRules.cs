using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{


    public class CarBusinessRules
    {
        private readonly ICarDal _carDal;

        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }
        // id değerine sahip aracı bul döndür
        public Car FindBrandId(int id)
        {
            Car car = _carDal.GetList().SingleOrDefault(x => x.Id == id);
            return car;
        }

        //modelYear değerine eşit olan aracı bul ve  döndür
        //public Car CheckIfCarModelYearsValid(int modelYear)
        //{

        //    Car car = _carDal.GetList().SingleOrDefault(x => x.ModelYear == modelYear);
        //    return car;
        //}

        //car nesnesi null mu? kontrol et
        public void CheckIfCarExists(Car? car)
        {
            if (car is null)
                throw new NotFoundException("Car not found.");
        }


    }
}
