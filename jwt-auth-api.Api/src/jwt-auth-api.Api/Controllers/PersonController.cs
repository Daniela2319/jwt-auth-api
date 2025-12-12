using jwt_auth_api.Api.ViewModel.PersonViewModel;
using jwt_auth_api.Application.Service;
using jwt_auth_api.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly PersonService  _servicePerson;
        public PersonController(PersonService servicePerson)
        {
            _servicePerson = servicePerson;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> person = _servicePerson.Read();
            List<PersonGetResponse> response = new List<PersonGetResponse>();
            foreach (var p in person)
            {
                response.Add(new PersonGetResponse
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    CreatedAt = p.CreatedAt
                });
            }
            return Ok(response);
        }
           
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person model = _servicePerson.ReadById(id);
            var response = new PersonGetResponse
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = model.CreatedAt,
            };
            return Ok(response);
        }

        [HttpGet("exist/{id}")]
        public IActionResult Exist(int id)
        {
            var response = new ExistResponse
            {
                Id = id,
                Exist = _servicePerson.Exists(id)
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonPostRequest request)
        {
            Person model = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            _servicePerson.Create(model);
            return Created();
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonPostRequest request)
        {
            Person model = new Person
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _servicePerson.Update(model);
            return NoContent();
              
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                this._servicePerson.Delete(id);
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
