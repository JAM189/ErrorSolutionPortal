using ErrorSolutionPortal.Application;
using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSolutionPortal.Controllers
{
    [Authorize]
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
            var searchResult = await errorAppService.Get(search);
            return PartialView("ErrorList", searchResult.Data.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ErrorSolution());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ErrorSolution error)
        {
            await errorAppService.Create(error);
            return RedirectToAction("Index", "Error");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string key)
        {
            var error = await errorAppService.Get(Guid.ParseExact(key, "N"));
            return View(error);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorSolution error)
        {
            await errorAppService.Update(error);
            return RedirectToAction("Index", "Error");
        }
    }
}
