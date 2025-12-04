using jwt_auth_api.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Infrastructure.Repositories
{
    public class RepositoryPerson : RepositoryInDbPostgres
    {
        public RepositoryPerson(ApplicationDbContext context) : base(context)
        {
        }
    }
}
