using jwt_auth_api.Api.ViewModel.UsersViewModel;
using jwt_auth_api.Application.Service;
using jwt_auth_api.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _serviceUsuario;
        private readonly PersonService _servicePerson;

        public UsuarioController(UsuarioService serviceUsuario, PersonService servicePerson)
        {
            _serviceUsuario = serviceUsuario;
            _servicePerson = servicePerson;
        }

        [HttpGet]
        public List<UserResponseViewModel> Get()
        {
            List<Usuario> usuarios =  _serviceUsuario.Read();
            List<UserResponseViewModel> listViewModel = new List<UserResponseViewModel>();
            foreach (var usuario in usuarios)
            {
                listViewModel.Add(new UserResponseViewModel
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    CreatedAt = usuario.CreatedAt,
                    Person = _servicePerson.ReadById(usuario.PersonId)
                }); //gerei o token no senha do usuario, depois é validar com jwt
            }
            return listViewModel;
        }


        [HttpGet("{id}")]
        public UserResponseViewModel Get(int id)
        {
            Usuario user = _serviceUsuario.ReadById(id);
            UserResponseViewModel userResponseViewModel = new UserResponseViewModel
            {
                Id = user.Id,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Person = _servicePerson.ReadById(user.PersonId)
            };
            return  userResponseViewModel;
        }

        [HttpGet("exist/{id}")]
        public bool Exist(int id)
        {
            return  _serviceUsuario.Exists(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequestViewModel viewModel)
        {
            Usuario model = new Usuario
            {
                Email = viewModel.Email,
                Password = viewModel.Password,
                PersonId = viewModel.PersonId
            };
             _serviceUsuario.Create(model);
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserPasswordViewModel model)
        {
            if (id != model.Id)
            {
                throw new ArgumentException("O ID do objeto User não é igual ao ID da URL.");
            }

            Usuario userToUpdate = new Usuario();
            userToUpdate.Id = model.Id;
            userToUpdate.Password = model.Password;
            _serviceUsuario.Update(userToUpdate);
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                this. _serviceUsuario.Delete(id);
                StatusCodeResult result = new StatusCodeResult(204);
                return result;
            }
            catch (Exception)
            {
                StatusCodeResult result = new StatusCodeResult(500);
                return result;
            }

        }
    }
}
