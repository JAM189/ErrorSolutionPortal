using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ErrorSolutionPortal.Controllers
{
    public class HomeController
        : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IErrorManager errorRepo;
        //added for errormgr
        public HomeController(
            ILogger<HomeController> logger)
            //,
            //IErrorManager errorRepo)
        {
            _logger = logger;
         //   this.errorRepo = errorRepo;
        }

        public IActionResult Index()
        {
            //return errorRepo.GetById(Id).Solution;
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
