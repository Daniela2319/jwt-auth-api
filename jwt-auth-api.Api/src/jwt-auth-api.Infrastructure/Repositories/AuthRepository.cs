using jwt_auth_api.Core.Users;
using jwt_auth_api.Infrastructure.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Text;

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
