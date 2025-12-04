using jwt_auth_api.Application.Service;
using jwt_auth_api.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jwt_auth_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ServicePerson  _servicePerson;
        public PersonController(ServicePerson servicePerson)
        {
            _servicePerson = servicePerson;
        }
        [HttpGet]
        public List<Person> Get()
        {
            return _servicePerson.Read();
        }

        
        [HttpGet("{id}")]
        public Person Get(Guid id)
        {
            return _servicePerson.ReadById(id);
        }

        [HttpGet("exist/{id}")]
        public bool Exist(Guid id)
        {
            return _servicePerson.Exists(id);
        }

        [HttpPost]
        public void Post([FromBody] Person model)
        {
            _servicePerson.Create(model);
        }

        
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Person model)
        {
            _servicePerson.Update(model);
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(Guid id)
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
