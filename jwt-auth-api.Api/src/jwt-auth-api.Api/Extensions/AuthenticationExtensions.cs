using jwt_auth_api.Application.Auth.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace jwt_auth_api.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurações de Token
            var tokenConfigurations = configuration.GetSection("TokenConfigurations");
            var issuer = tokenConfigurations["Issuer"];
            var audience = tokenConfigurations["Audience"];
            var secret = tokenConfigurations["Secret"]
                        ?? throw new InvalidOperationException("JWT Secret não configurado.");
            services.Configure<TokenConfiguration>(tokenConfigurations);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = issuer,
                       ValidAudience = audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                       RoleClaimType = ClaimTypes.Role
                   };
               });

            return services;
        }
    }
}
