using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data
{
    public interface IGenericRepository<T> where T:class
    {
        //id'ye göre getir
        T Get(int id);
        //tüm listeyi getir
        IQueryable<T> GetAll();
        //listeden bul
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        //Ekleme 
        void Add(T entity);
        //Düzenleme
        void Edit(T entity);
        //Silme
        void Delete(T entity);
        //Kaydet
        void Save();

    }
}
