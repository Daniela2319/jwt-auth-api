using jwt_auth_api.Core;
using jwt_auth_api.Infrastructure.Context;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class RepositoryInDbPostgres : BaseRepository<Person>
    {
        public RepositoryInDbPostgres(ApplicationDbContext context) : base(context)
        {
        }
    }
}
