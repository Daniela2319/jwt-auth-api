using jwt_auth_api.Domain.Users;
namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserGetResponseViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;

        // Foreign Key para Person - POO Composição
        public Person Person { get; set; } = new Person();
    }
}
