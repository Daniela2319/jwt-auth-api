using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.PersonViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo Primeiro Nome é obrigatório.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string LastName { get; set; } = string.Empty;
        
    }
}
