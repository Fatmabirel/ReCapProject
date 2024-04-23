using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
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

        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            _CarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorResult(Messages.MaintanenceTime);
            }
            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_CarDal.Get(c => c.CarId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanenceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails(), Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorResult(Messages.MaintanenceTime);
            }
            _CarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
