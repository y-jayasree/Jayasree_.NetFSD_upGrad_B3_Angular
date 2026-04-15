using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.Services;

namespace WebApplication14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _service;

        public ContactsController(ContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts(int pageNumber = 1, int pageSize = 5)
        {
            var result = await _service.GetContacts(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            var result = await _service.AddContact(contact); 
            return Ok(result);
        }

    }
}
    
