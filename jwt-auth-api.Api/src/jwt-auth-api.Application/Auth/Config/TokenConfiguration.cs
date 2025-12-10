using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Application.Auth.Config
{
    public class TokenConfiguration
    {
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        

    }
}
