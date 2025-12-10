using jwt_auth_api.Application.Auth.Tools;
using jwt_auth_api.Application.Service;
using jwt_auth_api.Core.Users;
using jwt_auth_api.Infrastructure.Repositories;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace jwt_auth_api.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            services.AddScoped<PersonService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<AuthService>();
            services.AddScoped<TokenGenerator, TokenGenerator>();
            services.AddScoped<PasswordHasher<Usuario>>();

            // ===== Repositories =====
            services.AddScoped(typeof(IRepositoriy<>), typeof(GeneriRepository<>));
            services.AddScoped<AuthRepository>();
            return services;
        }

    }
}
