using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserPutRequestViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Senha deve ter no mínimo 3 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}
