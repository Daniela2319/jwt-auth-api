using jwt_auth_api.Core.Users;
using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserRequestViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Password { get; set; } = string.Empty;
        public int PersonId { get; set; } 
    }
}
