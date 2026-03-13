using PhotoService.Application.Interfaces;
using PhotoService.Infrastucture.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoService.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddHttpClient<IPhotoRepository, PhotoRepository>();
            return services;
        }
    }
}
