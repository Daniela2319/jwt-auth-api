using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class Usuario : BaseModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
        public Guid PersonId { get; set; }
    }
}
