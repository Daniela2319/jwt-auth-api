using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class RolePermissao : BaseModel
    {
        public Guid RoleId { get; set; }
        public Guid PermissaoId { get; set; }
    }
}
