using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            // Arabanın kiralanabilir durumda olup olmadığını kontrol et
            if (!IsCarAvailableForRent(rental.CarId))
            {
                return new ErrorResult("Araba şu anda kiralanamaz, başka bir tarih seçiniz.");
            }

            // Kiralama işlemini gerçekleştir
            _rentalDal.Add(rental);
            return new SuccessResult("Araba başarıyla kiralandı.");
        }

        private bool IsCarAvailableForRent(int carId)
        {
            // Arabanın teslim edilip edilmediğini kontrol et
            var rentedCar = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            return rentedCar == null; // Teslim edilmemiş araç yoksa, araç kiralanabilir durumdadır.
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
