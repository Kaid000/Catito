using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration.Extentions
{


    public static class RepositoriesExtention
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();

        }
    }

}
