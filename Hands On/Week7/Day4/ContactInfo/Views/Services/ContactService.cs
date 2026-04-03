using WebApplication4.Models;
using WebApplication4.Repository;
using System.Collections.Generic;

namespace WebApplication4.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public List<ContactInfo> GetAllContacts() => _repo.GetAllContacts();
        public ContactInfo GetContactById(int id) => _repo.GetContactById(id);
        public void AddContact(ContactInfo contact) => _repo.AddContact(contact);
        public void UpdateContact(ContactInfo contact) => _repo.UpdateContact(contact);
        public void DeleteContact(int id) => _repo.DeleteContact(id);

        // For dropdowns
        public List<Company> GetAllCompanies() => _repo.GetAllCompanies();
        public List<Department> GetAllDepartments() => _repo.GetAllDepartments();
    }
}
