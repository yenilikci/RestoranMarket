using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext context;

        public GenericRepository(DbContext _context)
        {
            context = _context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public System.Linq.IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
