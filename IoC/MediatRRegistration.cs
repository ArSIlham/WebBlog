using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Handler.CQRS.Queries;

namespace WebApplication13.IoC
{
    public static class MediatRRegistration
    {
        public static void RegisterMediatR(IServiceCollection services)
        {
            //Owner
            services.AddMediatR(Assembly.GetAssembly(typeof(CreatePost.CreatePostRequest)));




        }
    }
}
