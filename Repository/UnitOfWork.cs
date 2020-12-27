using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext context;

        public UnitOfWork(RestaurantContext _context)
        {
            context = _context ?? throw new ArgumentNullException("dbcontext can not be null");
        }

        public IRestaurantRepository _restaurants;

        public ICategoryRepository _categories;

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new CategoryRepository(context));
            }
        }

        public IRestaurantRepository Restaurants
        {
            get
            {
                return _restaurants ?? (_restaurants = new RestaurantRepository(context));
            }
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
