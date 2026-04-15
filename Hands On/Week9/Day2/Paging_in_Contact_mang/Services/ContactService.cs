using WebApplication14.Models;
using WebApplication14.Data;
using WebApplication14.DTOs;   
using Microsoft.EntityFrameworkCore;

namespace WebApplication14.Services
{
    public class ContactService
    {
        private readonly ContactDbContext _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<Contact>> GetContacts(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Contacts.CountAsync();

            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await _context.Contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }
        public async Task<Contact> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

    }
}
