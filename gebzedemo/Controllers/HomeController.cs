using gebzedemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace gebzedemo.Controllers
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

        public IActionResult cesmeler() { return View(); }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Camiiler()
        {
            return View();
        }
        public IActionResult Kalevekuleler()
        {
            return View();
        }
        public IActionResult Hamamlar()
        {
            return View();
        }
        public IActionResult Dogaturizmi()
        {
            return View();
        }
        public IActionResult Yemekler()
        {
            return View();
        }
        public IActionResult Sehitlik()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
