namespace jwt_auth_api.Domain.Users
{
    public class Usuario : BaseModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
        public int PersonId { get; set; }
       
    }
}
