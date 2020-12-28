using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context)
        {

        }
    }
}
