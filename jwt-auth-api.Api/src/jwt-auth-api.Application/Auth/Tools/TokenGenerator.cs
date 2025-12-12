using jwt_auth_api.Application.Auth.Config;
using jwt_auth_api.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt_auth_api.Application.Auth.Tools
{
    public class TokenGenerator
    {
        private readonly TokenConfiguration _tokenConfiguration;
        public TokenGenerator(IOptions<TokenConfiguration> tokenConfiguration)
        {
            this._tokenConfiguration = tokenConfiguration.Value;
        }
        public string GenerateToken(Usuario model, Person person)
        {
            // ===== Claims do Token =====
            var claims = new List<Claim>
            {
                new Claim("FirstName", person.FirstName),
                new Claim("LastName", person.LastName),
                new Claim("Email", model.Email),
                new Claim("UsuarioId", model.Id.ToString()),
                new Claim("PersonId", model.PersonId.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);

            // ===== Gera o token =====
            var token = new JwtSecurityToken(
                issuer: _tokenConfiguration.Issuer,
                audience: _tokenConfiguration.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }
    }
}
