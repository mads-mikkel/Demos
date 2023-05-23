using DataAccess;

using Entities;

namespace DataAccessTests
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void Test1()
        {
            Repository<Order> orderRepo = new(new());
            Repository<Customer> customerRepo = new(new());

            var allOrders = orderRepo.GetAll();
            var allCustomers = customerRepo.GetAll();

            DateTime d = new(1997, 04, 01);
            var x = orderRepo.Get(o => o.OrderDate > d, q => q.OrderBy(o => o.OrderDate), $"{nameof(Employee)}s");
        }
    }
}