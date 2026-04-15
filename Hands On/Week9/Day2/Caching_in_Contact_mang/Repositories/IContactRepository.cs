using WebApplication10.Models;

namespace WebApplication10.Repositories
{
    public interface IContactRepository
    {
        List<Contact>GetAllContacts();
        Contact GetContactById(int id);
    }
}
