using jwt_auth_api.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace jwt_auth_api.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
