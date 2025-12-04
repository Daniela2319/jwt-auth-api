using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{this.Id} - {this.CreatedAt}";
        }
    }
}
