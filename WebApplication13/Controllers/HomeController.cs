using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication13.Data;
using Microsoft.Extensions.DependencyInjection;


namespace WebApplication13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        //private UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger)
        {
         
        
            _logger = logger;
        }

        int pageSize = 2;
    
        public async Task<IActionResult> Index()
        {
           

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
