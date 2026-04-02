using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class ContactService : IContactService
    {
        // Static list acting as in-memory database
        private static readonly List<ContactInfo> contacts =
        [
            new ContactInfo { ContactId = 1, FirstName = "John", LastName = "Doe", CompanyName = "ABC", EmailId = "john@gmail.com", MobileNo = 9876576545, Designation = "Manager" },
            new ContactInfo { ContactId = 2, FirstName = "smith", LastName = "Sharma", CompanyName = "XYZ", EmailId = "s@gmail.com", MobileNo = 9123456780, Designation = "Developer" }
        ];


        // Add new contact
        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }

        // Get all contacts
        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        // Get contact by ID
        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}


