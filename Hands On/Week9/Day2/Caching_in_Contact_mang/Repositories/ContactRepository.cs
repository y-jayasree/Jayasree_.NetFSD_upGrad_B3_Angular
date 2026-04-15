using WebApplication10.Models;

namespace WebApplication10.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new List<Contact>
    {
        new Contact { Id = 1, Name = "Amit", Email = "amit@gmail.com" },
        new Contact { Id = 2, Name = "Ravi", Email = "ravi@gmail.com" },
        new Contact { Id = 3, Name = "Sita", Email = "sita@gmail.com" }
    };
        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }
        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}