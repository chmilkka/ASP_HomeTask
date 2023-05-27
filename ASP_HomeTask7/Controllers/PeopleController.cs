using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP_HomeTask7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public static List<Person> People = new List<Person>();

        [HttpGet]
        public ActionResult GetPeople()
        {
            if (People.Count == 0)
            {
                return NoContent();
            }
            return Ok(People);
        }

        [HttpGet("{id}")]
        public ActionResult GetPerson([FromRoute] int id)
        {
            var person = People.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return BadRequest(new { ErrorMassage = $"{id} ID not found" });
            }
            else
            {
                return Ok(person);
            }
                
        }
        [HttpPost]
        public ActionResult CreatePerson([FromQuery] string firstName, string lastName)
        {
            var person = new Person
            {
                Id = People.Count + 1,
                FirstName = firstName,
                LastName = lastName
            };
            People.Add(person);
            return Ok(person);         
        }
        [HttpPut]
        public ActionResult UpdatePerson([FromQuery] Person updatePerson)
        {
            var person = People.FirstOrDefault(x => x.Id == updatePerson.Id);
            if (person == null) return BadRequest(new { ErrorMassage = "Person with this id was not found" });

            person.FirstName = updatePerson.FirstName;
            person.LastName = updatePerson.LastName;
            return Ok(person);        
        }
        [HttpDelete]
        public ActionResult DeletePerson(int id)
        {
            var person = People.FirstOrDefault(x =>x.Id == id);
            if (person == null) return BadRequest(new { ErrorMassage = "Person with this id was not found" });
            People.Remove(person);
            return Ok(person);
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
