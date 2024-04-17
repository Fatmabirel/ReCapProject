using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach(var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId+ " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear.ToShortDateString() + " "+ car.DailyPrice + " " + car.Description);
            }
        }
    }
}