using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Portal.PL.Models;
using System.Diagnostics;

namespace Portal.PL.Controllers
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
            Console.WriteLine("BeforeHangeFire");
            BackgroundJob.Enqueue(()=> printMessageInConsole());
            Console.WriteLine("AfterHangeFire");


            return View();
        }
        public void printMessageInConsole()
        {
            Console.WriteLine("Print1");
            Console.WriteLine("Print2"); 
            Console.WriteLine("Print3");
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
