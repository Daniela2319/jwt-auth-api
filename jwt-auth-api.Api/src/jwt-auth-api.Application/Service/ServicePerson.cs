using jwt_auth_api.Core;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;


namespace jwt_auth_api.Application.Service
{
    public class ServicePerson : BaseService<Person>
    {
        public ServicePerson(IRepositoriy<Person> repository) : base(repository)
        {
        }
    }
}
