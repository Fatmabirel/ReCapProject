using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
            }

            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public Car GetCarsByBrandId(int brandId)
        {
            return _CarDal.Get(c=>c.BrandId ==  brandId);
        }

        public Car GetCarsByColorId(int colorId)
        {
            return _CarDal.Get(c => c.ColorId == colorId);
        }
    }
}
