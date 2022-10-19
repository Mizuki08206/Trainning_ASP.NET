using Microsoft.AspNetCore.Mvc;

namespace SampleMvc.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World!!");
        }
        public IActionResult Index1()
        {
            return Content("こんにちは!!");
        }
    }
}
