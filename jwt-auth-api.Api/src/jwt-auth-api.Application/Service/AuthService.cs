using jwt_auth_api.Application.Auth.Tools;
using jwt_auth_api.Core.Users;
using jwt_auth_api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;


namespace jwt_auth_api.Application.Service
{
    public class AuthService
    {
        // Injetar dependências necessárias, como repositórios e serviços de hashing de senha
        private readonly AuthRepository _authRepository;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;

        public AuthService(AuthRepository authRepository, PasswordHasher<Usuario> sha256PasswordHasher, TokenGenerator tokenGenerator)
        {
            _authRepository = authRepository;
            _passwordHasher = sha256PasswordHasher;
            _tokenGenerator = tokenGenerator;
        }
        public string Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Email e senha são obrigatórios.");

            var model = _authRepository.GetUserByEmail(email);
            if (model == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            var result = _passwordHasher.VerifyHashedPassword(model, model.Password, password);
            if (result != PasswordVerificationResult.Success)
                throw new UnauthorizedAccessException("Senha inválida.");

            var token = _tokenGenerator.GenerateToken(model);
            if (string.IsNullOrEmpty(token))
                throw new ApplicationException("Falha ao gerar token.");

            return token;
        }

        public string Logout()
        {
            return "Logout bem-sucedido.";
        }

    }
}
