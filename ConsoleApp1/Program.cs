using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car newCar = new Car
            {
                BrandId = 1, // Örnek bir marka ID'si
                ColorId = 1, // Örnek bir renk ID'si
                ModelYear = DateTime.Now.AddYears(-3), // Örnek bir model yılı
                DailyPrice = 150, // Günlük fiyat
                Description = "d" // Açıklama
            };

            // Yeni arabayı eklemek için AddCar metodu çağrılır
            carManager.Add(newCar);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId+ " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear.ToShortDateString() + " "+ car.DailyPrice + " " + car.Description);
            }

        }
    }
}