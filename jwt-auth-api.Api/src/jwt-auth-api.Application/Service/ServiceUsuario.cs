using jwt_auth_api.Core;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwt_auth_api.Application.Service
{
    public class ServiceUsuario : BaseService<Usuario>
    {
        public ServiceUsuario(IRepositoriy<Usuario> repository) : base(repository)
        {
        }
    }
}
