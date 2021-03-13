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
using Application.Handler.CQRS.Queries;
using WebApplication13.Handler;

namespace WebApplication13.Controllers.AdminController
{
    public class AdminController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Createpost()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Createpost(CreatePost.CreatePostRequest create)
        {
            var result = await Mediator.Send(create);

            return HandleResponse.Response(result);
        }
        public IActionResult Edit_Post()
        {
            return View();
        }
        public IActionResult Delete_Post()
        {
            return View();
        }
    }
}
