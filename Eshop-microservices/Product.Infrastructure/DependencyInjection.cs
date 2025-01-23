using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interface;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ProductInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProduct, ProductServices.ProductServices>();
            return services;
        }
    }
}
