using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class Token : BaseModel
    {
        public Guid UsuarioId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; } 

    }
}
