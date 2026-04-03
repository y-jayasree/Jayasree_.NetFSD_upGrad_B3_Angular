using WebApplication4.Models;
using System.Collections.Generic;

namespace WebApplication4.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();

    }
}
