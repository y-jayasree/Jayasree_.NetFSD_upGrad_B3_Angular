using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        public ContactController(IContactRepository repo) => _repo = repo;

        [Route("")]
        [Route("ShowContacts")]
        public IActionResult ShowContacts() => View("ShowContacts", _repo.GetAllContacts());

        [HttpGet("AddContact")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetAllCompanies();
            ViewBag.Departments = _repo.GetAllDepartments();
            return View("AddContact");
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Companies = _repo.GetAllCompanies();
                ViewBag.Departments = _repo.GetAllDepartments();
                return View("AddContact", contact);
            }
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return RedirectToAction("ShowContacts");
            ViewBag.Companies = new SelectList(_repo.GetAllCompanies(), "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_repo.GetAllDepartments(), "DepartmentId", "DepartmentName", contact.DepartmentId);

            return View("EditContact", contact);
        }

        [HttpPost("EditContact/{id}")]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Companies = new SelectList(_repo.GetAllCompanies(), "CompanyId", "CompanyName", contact.CompanyId);
                ViewBag.Departments = new SelectList(_repo.GetAllDepartments(), "DepartmentId", "DepartmentName", contact.DepartmentId);

                return View("EditContact", contact);
            }

            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }


        [HttpGet("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id) => View("DeleteContact", _repo.GetContactById(id));

        [HttpPost("DeleteContact/{id}"), ActionName("DeleteContact")]
        public IActionResult DeleteContactConfirmed(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
        [HttpGet("ViewContact/{id}")]
        public IActionResult ViewContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return RedirectToAction("ShowContacts");
            return View("ViewContact", contact);
        }

    }
}
