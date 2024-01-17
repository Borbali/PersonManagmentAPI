using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagmentAPI.Model;


namespace PersonManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonContext Ctx;

        public PersonController(PersonContext context)
        {
            Ctx =  context;
        }

        [HttpPost]
        public IActionResult CreateNewPerson([FromBody] Person person)
        {
            Person checkPersonID = Ctx.Persons.Find(person.Id);

            if (!ModelState.IsValid || checkPersonID!=null)
            {
                return BadRequest("Invalid format");
            }

            Ctx.Persons.Add(person);
            Ctx.SaveChanges();

            return GetPersonById(person.Id);
        }
        // GET: api/<ValuesController>
        
        [HttpGet("all")]
        public IActionResult GetAllPeople()
        {
            var persons = Ctx.Persons.ToList();

            if (persons == null || persons.Count == 0)
            {
                return NotFound();
            }

            return Ok(persons);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = Ctx.Persons.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Person person)
        {
            var OldPerson = Ctx.Persons.Find(id);

            if (id != person.Id)
            {
                return BadRequest("Person with this ID does not exist");
            }
            OldPerson.Name= person.Name;
            OldPerson.Email= person.Email;
            OldPerson.PhoneNumber= person.PhoneNumber;
            OldPerson.DateOfBirth= person.DateOfBirth;
            Ctx.SaveChanges();
            return Ok(person);
        }

        // DELETE api/>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id,[FromBody] Person person)
        {
     
            if (id != person.Id){
                return BadRequest("Person with this ID does not exist");
            }
            Ctx.Persons.Remove(person);
            Ctx.SaveChanges();

            return Ok(person);
        }
        [HttpGet("find/name/{name}")]
        public IActionResult GetPersonByName(string name)
        {
            var person = Ctx.Persons.Find(name);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
        [HttpGet("find/email/{email}")]
        public IActionResult GetPersonByEmail(string email)
        {
            var person = Ctx.Persons.Find(email);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
