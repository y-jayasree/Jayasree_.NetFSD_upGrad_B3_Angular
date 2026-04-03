using WebApplication4.Models;
using System.Collections.Generic;

namespace WebApplication4.Repository
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        // Added for dropdowns
        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}
