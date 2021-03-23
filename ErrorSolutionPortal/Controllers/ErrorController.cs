using ErrorSolutionPortal.Application;
using ErrorSolutionPortal.Entities;
using ErrorSolutionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public async Task<SearchResult> GetAll(SearchModel search)
        {
            return await errorAppService.Get(search);
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
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(ErrorSolution error)
        {
            throw new NotImplementedException();
        }
    }
}
