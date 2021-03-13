
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication13.Persistence.Repositories;

namespace WebApplication13.IoC
{
    public static class RepositoryRegistration
    {
        public static void RegisterRepo(IServiceCollection services)
        {
            services.AddTransient<IOwnerRepository, OwnersRepository>();
      
        }
    }
}
