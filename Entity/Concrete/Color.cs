using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    //çıplak class kalmasın
    public class Color: IEntity
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
    }
}
