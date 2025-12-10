using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserPasswordViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Password { get; set; } = string.Empty;
    }
}
