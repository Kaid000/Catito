using Application.Repositories;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration.Extentions
{


    public static class ServiceExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();

        }
    }

}
