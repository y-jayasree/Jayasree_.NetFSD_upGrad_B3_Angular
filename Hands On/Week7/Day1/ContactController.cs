using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>();
        
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
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

            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }

    }
}
