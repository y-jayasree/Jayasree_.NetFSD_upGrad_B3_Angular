using WebApplication6.Models;
using WebApplication6.Repository;

namespace WebApplication6.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(ContactInfo contact)
        {
            await _repo.AddAsync(contact);
            return "Created";
        }

        public async Task<string> UpdateAsync(int id, ContactInfo contact)
        {
            if (id != contact.ContactId)
                return "Invalid Id";

            await _repo.UpdateAsync(contact);
            return "Updated";
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return "Deleted";
        }
    }
}

