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
            //CarTest();

            // UserTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal()); // Veri erişim katmanına göre uygun repository sınıfını kullanın

            // Araba kiralama için gerekli bilgileri hazırlayın
            Rental rental = new Rental
            {
                CarId = 1, // Kiralanacak arabanın Id'si
                CustomerId = 2, // Kiralayan müşterinin Id'si
                RentDate = DateTime.Now, // Kiralama tarihi (şu anki zaman)
                ReturnDate = null // Araba henüz teslim edilmediği için ReturnDate null olmalıdır
            };

            // Araba kiralama işlemini gerçekleştirin
            var result = rentalManager.Add(rental);

            // Sonucu ekrana yazdırın
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //User user1 = new User { FirstName = "Gi", LastName = "Kahraman", Email = "gizem@gmail.com", Password = "gizem123" };


            foreach (var user in userManager.GetAll().Data)
            {

                Console.WriteLine(user.FirstName);
            }
        }

        private static void CarTest()
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
        }
    }
}