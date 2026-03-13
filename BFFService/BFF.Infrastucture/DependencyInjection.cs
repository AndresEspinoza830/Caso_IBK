using BFF.Application.Interfaces;
using BFF.Infrastucture.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BFF.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddHttpClient<IProfileRepository, ProfileRepository>();
            return services;
        }
    }
}
