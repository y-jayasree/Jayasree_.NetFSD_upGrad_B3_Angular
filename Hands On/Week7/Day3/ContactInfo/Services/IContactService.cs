using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById (int id );
        void AddContact(ContactInfo contact); // add contact
    }
}
