using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using zrak.Models;
using zrak.Services;

namespace zrak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHelloService _helloService;
        public HomeController(ILogger<HomeController> logger, IHelloService helloService)
        {
            _logger = logger;
            _helloService = helloService;
        }

        public IActionResult Index()
        {
            return View(_helloService.GetHello());
        }

        public IActionResult BlogView() 
        {
            return View();
        }

        public IActionResult Privacy()
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
