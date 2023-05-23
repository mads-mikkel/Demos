using Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(NorthwindContext context) : base(context) { }

        public override IEnumerable<Order> GetAll()
            => dbSet.OrderByDescending(o => o.OrderDate).ToList();

        public async Task<IEnumerable<Order>> GetAllAsync()
            => await dbSet.OrderByDescending(o => o.OrderDate).ToListAsync();

        public Order[] GetOrdersArray()
        {
            return default;
        }


        public override void Insert(Order t) => base.Insert(t);
        public override void Update(Order order) => base.Update(order);
    }
}
