namespace jwt_auth_api.Core
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{base.ToString()} - {this.FirstName} - {this.LastName})";
        }

    }
}
