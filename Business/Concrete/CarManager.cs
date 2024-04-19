using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
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

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _CarDal.Get(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
