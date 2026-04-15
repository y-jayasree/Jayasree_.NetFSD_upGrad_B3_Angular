using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Exceptions;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> contacts = new();

        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
                throw new ValidationException("Invalid contact data");

            contact.Id = contacts.Count + 1;
            contacts.Add(contact);

            _logger.LogInformation("Contact created: {Name}", contact.Name);

            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
                throw new NotFoundException($"Contact not found with ID {id}");

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact updated)
        {
            if (!ModelState.IsValid)
                throw new ValidationException("Invalid contact data");

            var contact = contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
                throw new NotFoundException($"Contact not found with ID {id}");

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;

            _logger.LogInformation("Contact updated: {Id}", id);

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
                throw new NotFoundException($"Contact not found with ID {id}");

            contacts.Remove(contact);

            _logger.LogInformation("Contact deleted: {Id}", id);

            return Ok("Deleted successfully");
        }
    }
}
    
