using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ProductAPIApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
