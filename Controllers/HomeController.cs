using Microsoft.AspNetCore.Mvc;
using Payroll_Calculator.Models;
using System.Diagnostics;

namespace Payroll_Calculator.Controllers
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
        public IActionResult About()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PieceworkWorkerModel model)
        {
            // If all of the input is valid for this model.

            if (ModelState.IsValid)
            {

                model.GetPay();
                return View(model);
            }
            else
            {
                return View();
            }

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