using System.ComponentModel.DataAnnotations;

namespace jwt_auth_api.Api.ViewModel.PersonViewModel
{
    public class PersonPostRequest
    {
        [Required(ErrorMessage = "O campo Primeiro Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo FirstName deve ter no mínimo 3 caracteres")]
        public string FirstName { get; set; } 
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo FirstName deve ter no mínimo 3 caracteres")]
        public string LastName { get; set; }
    }
}
