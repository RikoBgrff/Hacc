using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();
        public void Insert(T t)
        {
            context.Entry(t).State = EntityState.Modified;
            context.Add(t);
            context.SaveChanges();
        }
        public void Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;

            context.Update(t);
            context.SaveChanges();
        }
        public void Delete(T t)
        {
            context.Entry(t).State = EntityState.Modified;

            context.Remove(t);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
