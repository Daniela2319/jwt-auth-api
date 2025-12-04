using jwt_auth_api.Core;
using Microsoft.EntityFrameworkCore;

namespace jwt_auth_api.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }
        public DbSet<RolePermissao> RolePermissaos { get; set; }
        public DbSet<Permissao> Permissaos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
