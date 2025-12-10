using jwt_auth_api.Core.Users;

namespace jwt_auth_api.Api.ViewModel.UsersViewModel
{
    public class UserResponseViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public Person Person { get; set; } = new Person();
    }
}
