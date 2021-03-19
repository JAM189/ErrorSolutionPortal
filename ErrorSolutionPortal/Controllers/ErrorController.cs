using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ErrorSolutionPortal.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IErrorManager errorRepo;
        //added for errormgr

        public ErrorController(
            IErrorManager errorRepo)
        {           
            this.errorRepo = errorRepo;
        }
        public IActionResult Index()
        {
            // ErrorSolution errorSolution = errorRepo.GetByProp(Name).Solution;
            //return View(errorSolution);
            return View();
        }
    }
}

//TODO: Add Index action method in ErrorController
//add textBox using form submission, load all the Erors from Db
