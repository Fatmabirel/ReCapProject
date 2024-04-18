using DataAccess.Abstract;
using Entity.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var addedValue = context.Entry(entity);
                addedValue.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var deletedValue = context.Entry(entity);
                deletedValue.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Color>().FirstOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList() :
                    context.Set<Color>().Where(filter).ToList();

            }
        }

        public void Update(Color entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var updatedValue = context.Entry(entity);
                updatedValue.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
