namespace jwt_auth_api.Domain
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{this.Id} - {this.CreatedAt}";
        }
    }
}
