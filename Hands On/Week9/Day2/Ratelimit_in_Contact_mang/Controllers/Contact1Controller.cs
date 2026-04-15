using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class Contacts1Controller : ControllerBase

    {
        private static List<Contact1> contacts = new List<Contact1>
        {
            new Contact1 { ContactId = 1, Name = "John", Email = "john@gmail.com", Phone = "1234567890" },
            new Contact1 { ContactId = 2, Name = "Alice", Email = "alice@gmail.com", Phone = "9876543210" }
        };

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }
    }
}
