using System.Diagnostics.Metrics;

using WebApplication7.Models;

namespace WebApplication7.DataAccess
{
    public class ContactRepository:IContactRepository
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo()
            {
                ContactId = 1,
                FirstName = "Jaya",
                LastName = "sree",
                EmailId = "Jaya@gmail.com",
                MobileNo = 9876543210,
                Designation = "xyz",
                CompanyId = 1,
                DepartmentId = 10
            },
            new ContactInfo()
            {
                ContactId = 2,
                FirstName = "A",
                LastName = "B",
                EmailId = "AB@gmail.com",
                MobileNo = 0987654321,
                Designation = "Developer",
                CompanyId = 2,
                DepartmentId = 20
            }
        };

        private static int counter = 3;
        
        public async Task<List<ContactInfo>> GetAllAsync() => await Task.FromResult(contacts);
        public async Task<ContactInfo> GetByIdAsync(int id) => await Task.FromResult(contacts.FirstOrDefault(c => c.ContactId == id));
        public async Task AddAsync(ContactInfo contact)
        {
            contact.ContactId = counter++;
            contacts.Add(contact);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(ContactInfo contact)
        {
            var index = contacts.FindIndex(c => c.ContactId == contact.ContactId);
            if (index != -1) contacts[index] = contact;
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact != null) contacts.Remove(contact);
            await Task.CompletedTask;
        }
    }
}
