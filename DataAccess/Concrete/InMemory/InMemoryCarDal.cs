using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal() {

            _cars = new List<Car>()
            {
                new Car{CarId = 1, BrandId = 1,ColorId = 1, DailyPrice = 15000,Description = "Ford Focus", ModelYear = new DateTime(2023, 1, 1)},
                new Car{CarId = 2, BrandId = 1,ColorId = 2, DailyPrice = 35000,Description = "Volkswagen Transit", ModelYear = new DateTime(2023, 5, 1)},
                new Car{CarId = 3, BrandId = 2,ColorId = 2, DailyPrice = 50000,Description = "Mercedes Benz", ModelYear = new DateTime(2020, 1, 1)},
                new Car{CarId = 4, BrandId = 2,ColorId = 3, DailyPrice = 12000,Description = "Renault Clio", ModelYear = new DateTime(2013, 1, 1)},
                new Car{CarId = 5, BrandId = 3,ColorId = 1, DailyPrice = 5000,Description = "Tofaş Şahin", ModelYear = new DateTime(2017, 1, 1)},
                new Car{CarId = 6, BrandId = 3,ColorId = 3, DailyPrice = 18000,Description = "Hyundai i20", ModelYear = new DateTime(2021, 1, 1)},
            };
        
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // find the id
            Car deletedValue = _cars.FirstOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(deletedValue);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c=>c.CarId ==CarId).ToList();
        }

        public void Update(Car car)
        {
            Car updatedValue = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            updatedValue.BrandId = car.BrandId;
            updatedValue.ColorId = car.ColorId;
            updatedValue.ModelYear = car.ModelYear;
            updatedValue.DailyPrice = car.DailyPrice;
            updatedValue.Description = car.Description;
        }
    }
}
