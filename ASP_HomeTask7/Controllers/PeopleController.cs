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
        public List<Person> GetPeople()
        {
            return People;
        }

        [HttpGet("{id}")]
        public Person? GetPerson([FromRoute] int id)
        {
            return People.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public Person CreatePerson([FromQuery] string firstName, string lastName)
        {
            var person = new Person
            {
                Id = People.Count + 1,
                FirstName = firstName,
                LastName = lastName
            };
            People.Add(person);
            return person;         
        }
        [HttpPut]
        public bool UpdatePerson([FromQuery] Person updatePerson)
        {
            var person = People.FirstOrDefault(x => x.Id == updatePerson.Id);
            if (person == null) return false;

            person.FirstName = updatePerson.FirstName;
            person.LastName = updatePerson.LastName;
            return true;        
        }
        [HttpDelete]
        public bool DeletePerson(int id)
        {
            var person = People.FirstOrDefault(x =>x.Id == id);
            if (person == null) return false;
            People.Remove(person);
            return true;
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
