using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Core
{
    public class Permissao : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
