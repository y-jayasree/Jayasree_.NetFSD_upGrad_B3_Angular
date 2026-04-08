using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.DataAccess;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        public ContactsController(IContactRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            return c == null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactInfo contact)
        {
            await _repo.AddAsync(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.ContactId }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContactInfo contact)
        {
            if (id != contact.ContactId) return BadRequest();
            await _repo.UpdateAsync(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
