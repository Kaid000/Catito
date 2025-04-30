using Application.Repositories;
using Application.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration.Extentions
{
    public static class RepositoriesExtention
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<ICatsRepository, CatsRepository>();
        }
    }
}
