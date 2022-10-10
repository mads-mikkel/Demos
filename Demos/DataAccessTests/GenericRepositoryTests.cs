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
        }
    }
}