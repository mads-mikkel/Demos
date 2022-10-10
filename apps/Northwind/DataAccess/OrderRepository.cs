using Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }

        public override IEnumerable<Order> GetAll()
        {
            return default;
        }

        public Order[] GetOrdersArray()
        {
            return default;
        }

        public override void Update(Order order)
        {

        }
    }
}
