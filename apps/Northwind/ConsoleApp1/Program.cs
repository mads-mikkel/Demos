using Entities;

using Microsoft.EntityFrameworkCore;

NorthwindContext context = new();

// 1.	Find alle produkter der ikke længere føres:
var result = context.Employees.OrderBy(e => e.ReportsToNavigation.LastName).ToList();
Print(result);

List<Order> o = context.Orders.Where(o => o.OrderDate >= DateTime.Now.Date && o.RequiredDate <= DateTime.Now.Date).Include(o => o.OrderDetails).ToList();

List<Product> p = new();
foreach (var order in o)
{
    foreach (var od in order.OrderDetails)
    {
        p.Add(od.Product);
    }
}

// 2.	Find alle leverandører fra Québec:

static void Print<T>(List<T> list)
{
    foreach (var item in list)
        Console.WriteLine(item);
}