using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AuthAPIApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
