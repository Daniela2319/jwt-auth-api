using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserPostRequestViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email está em um formato inválido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Senha deve ter no mínimo 3 caracteres.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "O id da pessoa precisa ser preenchido.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da pessoa precisa ser maior que 0.")]
        public int PersonId { get; set; } 
    }
}
