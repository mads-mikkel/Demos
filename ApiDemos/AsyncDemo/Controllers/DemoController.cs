using Microsoft.AspNetCore.Mvc;

namespace AsyncDemo.Controllers
{
    public class DemoController : Controller
    {
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
    }
}
