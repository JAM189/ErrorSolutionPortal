using Microsoft.AspNetCore.Mvc;

namespace ErrorSolutionPortal.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
