using jwt_auth_api.Api.ViewModel.PersonViewModel;
using jwt_auth_api.Api.ViewModel.UsersViewModel;
using jwt_auth_api.Application.Service;
using jwt_auth_api.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        public IActionResult Get()
        {
            List<Usuario> usuarios =  _serviceUsuario.Read();
            List<UserGetResponseViewModel> listViewModel = new List<UserGetResponseViewModel>();
            foreach (var usuario in usuarios)
            {
                listViewModel.Add(new UserGetResponseViewModel
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    CreatedAt = usuario.CreatedAt,
                    Person = _servicePerson.ReadById(usuario.PersonId)
                }); 
            }
            return Ok(listViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Usuario user = _serviceUsuario.ReadById(id);
            UserGetResponseViewModel userResponseViewModel = new UserGetResponseViewModel
            {
                Id = user.Id,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Person = _servicePerson.ReadById(user.PersonId)
            };
            return  Ok(userResponseViewModel);
        }

        [HttpGet("exist/{id}")]
        public IActionResult Exist(int id)
        {
            ExistResponse response = new ExistResponse
            {
                Id = id,
                Exist = _serviceUsuario.Exists(id)
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserPostRequestViewModel viewModel)
        {
            Usuario model = new Usuario
            {
                Email = viewModel.Email,
                Password = viewModel.Password,
                PersonId = viewModel.PersonId
            };
             _serviceUsuario.Create(model);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserPutRequestViewModel request)
        {
            Usuario model = new Usuario();
            model.Id = request.Id;
            model.Password = request.Password;

            _serviceUsuario.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                 _serviceUsuario.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
