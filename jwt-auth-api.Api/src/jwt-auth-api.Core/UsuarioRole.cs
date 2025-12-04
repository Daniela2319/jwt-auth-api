using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class UsuarioRole : BaseModel
    {
        public Guid UsuarioId { get; set; }
        public Guid RoleId { get; set; }
    }
}
