using WebApplication6.Models;

namespace WebApplication6.Services
{
    public interface IContactService
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task<string> CreateAsync(ContactInfo contact);
        Task<string> UpdateAsync(int id, ContactInfo contact);
        Task<string> DeleteAsync(int id);
    }
}
