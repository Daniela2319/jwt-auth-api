using jwt_auth_api.Api.ViewModel;
using jwt_auth_api.Api.ViewModel.PersonViewModel;
using jwt_auth_api.Application.Service;
using jwt_auth_api.Core.Users;
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
            List<PersonViewModel> listViewModel = new List<PersonViewModel>();
            foreach (var p in person)
            {
                listViewModel.Add(new PersonViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                }); 
            }
            return Ok(listViewModel);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(int id)
        {
            Person person = _servicePerson.ReadById(id);
            if (person == null)
                return NotFound();

            var personViewModel = new PersonViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return personViewModel;
        }


        [HttpGet("exist/{id}")]
        public IActionResult Exist(int id)
        {
            var response = _servicePerson.Exists(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonViewModel viewModel)
        {
            Person model = new Person
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName   
            };
            _servicePerson.Create(model);
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonViewModel viewModel)
        {
            Person model = new Person
            {
                Id = id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            _servicePerson.Update(model);
            return Ok(model);  
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
