using jwt_auth_api.Application.Auth.Tools;
using jwt_auth_api.Domain.Users;
using jwt_auth_api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;


namespace jwt_auth_api.Application.Service
{
    public class AuthService
    {
        // Injetar dependências necessárias, como repositórios e serviços de hashing de senha
        private readonly AuthRepository _authRepository;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;
        private readonly PersonService _personService;

        public AuthService(AuthRepository authRepository, PasswordHasher<Usuario> sha256PasswordHasher, TokenGenerator tokenGenerator, PersonService personService)
        {
            _authRepository = authRepository;
            _passwordHasher = sha256PasswordHasher;
            _tokenGenerator = tokenGenerator;
            _personService = personService;
        }
        public string Login(string email, string password)
        {
            var model = _authRepository.GetUserByEmail(email);
            if (model == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            var result = _passwordHasher.VerifyHashedPassword(model, model.Password, password);
            if (result != PasswordVerificationResult.Success)
            {
                var person = _personService.ReadById(model.PersonId);
                return _tokenGenerator.GenerateToken(model, person);
            }
            throw new Exception("Usuario ou senha invalido");
        }

        public string Logout()
        {
            return "Logout bem-sucedido.";
        }

    }
}
