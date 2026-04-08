using WebApplication7.Models;

namespace WebApplication7.DataAccess
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task AddAsync(ContactInfo contact);
        Task UpdateAsync(ContactInfo contact);
        Task DeleteAsync(int id);
    }
}
