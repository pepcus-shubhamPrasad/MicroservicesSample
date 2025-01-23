using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AuthInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryDatabase>();
            return services;
        }
    }
}
