using ErrorSolutionPortal.Application;
using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Controllers
{
    public class ErrorController
        : Controller
    {
        private readonly IErrorAppService errorAppService;

        public ErrorController(
            IErrorAppService errorAppService
            )
        {
            this.errorAppService = errorAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
            var error = await errorAppService.Get(Guid.ParseExact(key, "N"));
            return View(error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(SearchModel search)
        {
            var searchResult =  await errorAppService.Get(search);
            return PartialView("ErrorList", searchResult.Data.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(ErrorSolution error)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Edit(string key)
        {
            var error = errorAppService.Get(Guid.ParseExact(key, "N"));
            return View(error);
        }

        [HttpPost]
        public IActionResult Edit(ErrorSolution error)
        {
            throw new NotImplementedException();
        }
    }
}
