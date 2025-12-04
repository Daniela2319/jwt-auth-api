using jwt_auth_api.Infrastructure.Context;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class RepositoryUsuario : RepositoryInDbPostgres
    {
        public RepositoryUsuario(ApplicationDbContext context) : base(context)
        {
        }
    }
}
