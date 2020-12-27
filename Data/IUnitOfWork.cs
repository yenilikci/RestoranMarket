using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRestaurantRepository Restaurants { get; }
 
        ICategoryRepository Categories { get; }

        int SaveChanges();
    }
}
