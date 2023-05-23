using Entities;
using DataAccess;

using Microsoft.AspNetCore.Mvc;

namespace ServerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("/GetTime")]
        public ActionResult<string> GetTime()
        {
            Thread.Sleep(5000);
            return Ok($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.ffffff")}");
        }

        [HttpGet]
        [Route("/GetTimeAsync")]
        public async Task<ActionResult<string>> GetTimeAsync()
        {
            string time = "";
            await Task.Run(() => 
            { 
                Thread.Sleep(5000);
                time = $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.ffffff")}";
            });
            return Ok(time);
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            UnitOfWork unitOfWork = new(new());
            var orders = unitOfWork.OrderRepository.GetAll();
            return Ok(orders);
        }*/

        /*[HttpGet(Name = "GetOrdersAsync")]
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            UnitOfWork unitOfWork = new(new());
            return await unitOfWork.OrderRepository.GetAllAsync();
        }*/

        /*[HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            UnitOfWork unitOfWork = new(new());
            return unitOfWork.CategoryRepository.GetAll();
        }*/
    }
}
