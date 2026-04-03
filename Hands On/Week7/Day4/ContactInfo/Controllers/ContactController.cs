using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult ShowContacts()
        {
            var contacts = _service.GetAllContacts();
            return View(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpGet("add")]
        public IActionResult AddContact()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            PopulateDropdowns();
            return View(contact);
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null) return NotFound();
            PopulateDropdowns();
            return View(contact);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateContact(contact);
                return RedirectToAction("ShowContacts", "Contact");
            }

            PopulateDropdowns();
            return View(contact);
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _service.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        private void PopulateDropdowns()
        {
            // Get companies and departments from service
            var companies = _service.GetAllCompanies();
            var departments = _service.GetAllDepartments();

            // If null, replace with empty list
            companies = companies ?? new List<Company>();
            departments = departments ?? new List<Department>();

            // Pass to ViewBag safely
            ViewBag.Companies = new SelectList(companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
        }


    }
}
