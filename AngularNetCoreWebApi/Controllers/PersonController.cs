using Microsoft.AspNetCore.Mvc;
using PersonTestWebApi.Models;
using System.Net;
using System.Text.Json;
//using System.Web.Http;

namespace AngularNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly string personFilePath = "File\\person data.txt";

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("addPerson")]
        public ActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("person is not valid");
            }
            try
            {
                string peopleJsonText = System.IO.File.ReadAllText(personFilePath);
                List<Person> people = string.IsNullOrWhiteSpace(peopleJsonText) ? new List<Person>(): JsonSerializer.Deserialize<List<Person>>(peopleJsonText);
                
                if (!people.Any(p => p.IdNum == person.IdNum))
                {
                    people.Add(person);
                    peopleJsonText = JsonSerializer.Serialize(people);
                    using (StreamWriter writer = new StreamWriter(personFilePath))
                    {
                        writer.Write(peopleJsonText);
                    }
                    return Ok(JsonSerializer.Serialize(new Response() { IsSuccess = true }));
                }
                return Ok(JsonSerializer.Serialize(new Response() { IsSuccess = false }));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("getAllPeople")]
        public ActionResult GetAllPeople()
        {
            try
            {
                string peopleJsonText = System.IO.File.ReadAllText(personFilePath);
                List<Person> people = string.IsNullOrWhiteSpace(peopleJsonText) ? new List<Person>(): JsonSerializer.Deserialize<List<Person>>(peopleJsonText);
                
                if (people.Any())
                {
                    return Ok(JsonSerializer.Serialize(new Response() {IsSuccess = true, Result = peopleJsonText }));
                }
                return Ok(JsonSerializer.Serialize(new Response() { IsSuccess = false}));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("deleteData")]
        public ActionResult DeleteData()
        {
            try
            {
                System.IO.File.WriteAllText(personFilePath, string.Empty);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}