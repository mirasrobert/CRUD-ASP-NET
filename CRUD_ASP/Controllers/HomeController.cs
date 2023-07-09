using CRUD_ASP.Context;
using CRUD_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MYContext MYContext;

        public HomeController(MYContext mYContext, ILogger<HomeController> logger)
        {
            this.MYContext = mYContext;
            this._logger = logger;
        }

        public IActionResult Index(string message)
        {
            var employees = MYContext.Employees.ToList();

            ViewBag.Message = message;

            return View(employees);
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