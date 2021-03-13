
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication13.IoC
{
    public static class ServicesRegistration
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IOwnerService, OwnerService>();
     

        }
    }
}
