using Microsoft.AspNetCore.Mvc;
using practice_ASP.Models;
using System.Diagnostics;

namespace practice_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Input()//formタグのパラメータは基本的にstring型
        {
            return View();
        }
        public IActionResult Confirm(string tel,string gender)
        {
            ViewData["tel"] = tel;
            ViewData["gender"] = gender;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}