using jwt_auth_api.Core.Users;
using jwt_auth_api.Infrastructure.Context;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class RepositoryInDbPostgres : GeneriRepository<Person>
    {
        public RepositoryInDbPostgres(ApplicationDbContext context) : base(context)
        {
        }
    }
}
