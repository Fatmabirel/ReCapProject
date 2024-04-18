using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetCarsByBrandId(int brandId);
        Car GetCarsByColorId(int colorId);
        void Add(Car car);
    }
}
