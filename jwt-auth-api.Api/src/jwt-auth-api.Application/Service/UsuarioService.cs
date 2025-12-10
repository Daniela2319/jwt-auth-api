using jwt_auth_api.Core.Users;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace jwt_auth_api.Application.Service
{
    public class UsuarioService : GeneriService<Usuario>
    {
        private readonly PasswordHasher<Usuario> _passwordHasher;
        public UsuarioService(IRepositoriy<Usuario> repository, PasswordHasher<Usuario> sha256PasswordHasher) : base(repository)
        {
            _passwordHasher = sha256PasswordHasher;
        }

        public override int Create(Usuario model)
        {
            model.Password = _passwordHasher.HashPassword(model, model.Password);
            return base.Create(model);
        }

        public override void Update(Usuario model)
        {
            Usuario existingUser = ReadById(model.Id);
            if (existingUser != null)
            {
                model.Email = existingUser.Email; // Evita alterar o email
                model.PersonId = existingUser.PersonId; // Evita alterar o PersonId
                model.Password = _passwordHasher.HashPassword(model, model.Password); // Atualiza a senha com hash
            }
            base.Update(model);
        }

    }
}
