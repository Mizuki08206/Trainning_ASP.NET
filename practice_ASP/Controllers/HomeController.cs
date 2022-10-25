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
        public IActionResult Input()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry([Bind("Name", "Age", "Anime")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                ViewData["err"] = "エラーじゃないよ";
                return View("EntryConfirm", entry);
            }
            else
            {
                ViewData["err"] = "エラーだよ";
                return View("EntryConfirm", entry);
            }

        }
        public IActionResult Confirm(string tel, string gender)//formタグのパラメータは基本的にstring型
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