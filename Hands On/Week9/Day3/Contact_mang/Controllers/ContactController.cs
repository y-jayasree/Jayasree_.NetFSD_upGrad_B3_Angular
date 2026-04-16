using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;
using WebApplication13.Services;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _service.Add(contact);
            return Ok("Contact Added");
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            _service.Update(contact);
            return Ok("Contact Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Contact Deleted");
        }
    }
}


