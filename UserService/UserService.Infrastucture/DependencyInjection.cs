using UserService.Application.Interfaces;
using UserService.Infrastucture.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddHttpClient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
