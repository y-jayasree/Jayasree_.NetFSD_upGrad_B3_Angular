using System.Collections.Generic;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IContactRepository
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
