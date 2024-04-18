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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var addedValue = context.Entry(entity);
                addedValue.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var deletedValue = context.Entry(entity);
                deletedValue.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Brand>().FirstOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                return filter == null ?
                    context.Set<Brand>().ToList() :
                    context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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
