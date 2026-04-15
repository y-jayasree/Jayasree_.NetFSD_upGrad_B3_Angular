using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
