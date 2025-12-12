using jwt_auth_api.Infrastructure.Context;
namespace jwt_auth_api.Infrastructure.Repositories
{
    public class RepositoryPerson : RepositoryInDbPostgres
    {
        public RepositoryPerson(ApplicationDbContext context) : base(context)
        {
        }
    }
}
