using jwt_auth_api.Application.Service;
using jwt_auth_api.Infrastructure.Repositories;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;

namespace jwt_auth_api.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            services.AddScoped<ServicePerson>();

            // ===== Repositories =====
            services.AddScoped(typeof(IRepositoriy<>), typeof(BaseRepository<>));
            return services;
        }

    }
}
