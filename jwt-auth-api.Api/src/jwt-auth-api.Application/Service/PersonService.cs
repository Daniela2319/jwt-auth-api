using jwt_auth_api.Domain.Users;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace jwt_auth_api.Application.Service
{
    [Authorize(Roles = "Admin")]
    public class PersonService : GeneriService<Person>
    {
        public PersonService(IRepositoriy<Person> repository) : base(repository)
        {
        }

        public override void Update(Person model)
        {
            var existingPerson = ReadById(model.Id);
            existingPerson.FirstName = model.FirstName;
            existingPerson.LastName = model.LastName;

            base.Update(existingPerson);
        }
    }
}
