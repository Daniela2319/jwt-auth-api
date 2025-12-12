using jwt_auth_api.Domain.Users;
using jwt_auth_api.Infrastructure.Context;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class AuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Usuario? GetUserByEmail(string email)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}
