using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService; // Di
        // Constructor injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        // Show all contacts
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }
        public IActionResult AddContact()
        {
            return View();
        }
        // Save contact
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid) 
            {
                return View(contactInfo); 
            }

            _contactService.AddContact(contactInfo); // call service
            return RedirectToAction("ShowContacts"); // redirect to list
        }

    }
}
