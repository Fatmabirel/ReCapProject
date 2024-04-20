using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;
using System.Runtime.ConstrainedExecution;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {

                    Console.WriteLine(car.Description + " " + car.BrandName + " " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}


        }
    }
}