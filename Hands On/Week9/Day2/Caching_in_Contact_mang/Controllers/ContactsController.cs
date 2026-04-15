using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetAll()
        {
            var result = _service.GetAllContacts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetById(int id)
        {
            var result = _service.GetContactById(id);

            if (result == null)
                return NotFound("Contact not found");

            return Ok(result);
        }
    }
}
