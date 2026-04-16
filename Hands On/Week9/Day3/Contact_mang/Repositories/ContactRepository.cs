using WebApplication13.Data;
using WebApplication13.Models;
using Microsoft.EntityFrameworkCore;



namespace WebApplication13.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}

