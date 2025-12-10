namespace jwt_auth_api.Api.ViewModel
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
