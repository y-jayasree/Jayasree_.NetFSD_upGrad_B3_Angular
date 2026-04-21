using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ConsoleApp2

{
    internal class ContactService : IContactService
    {
        // Inmemory list to store contacts
        private readonly List<Contact> contacts = new();
        public void AddContact(Contact contact)
        {
            ValidateContact(contact);
            // Assign Id
            contact.Id = GenerateNextId();
            contacts.Add(contact);
        }
        public void UpdateContact(Contact contact)
        {
            ValidateContact(contact);
            var existingContact = GetContactById(contact.Id);

            // Update values
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
        }
        public void DeleteContact(int id)
        {
            var contact = GetContactById(id);
            contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return new List<Contact>(contacts);
        }

        // Validate input data
        private static void ValidateContact(Contact? contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                throw new ArgumentException("Name is required");
            }

            if (string.IsNullOrWhiteSpace(contact.Email))
            {
                throw new ArgumentException("Email is required");
            }

            if (string.IsNullOrWhiteSpace(contact.Phone))
            {
                throw new ArgumentException("Phone is required");
            }
        }


        // Get contact by Id
        private Contact GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            return contact;
        }

        // Generate next Id
        private int GenerateNextId()
        {
            return contacts.Count == 0 ? 1 : contacts.Max(c => c.Id) + 1;
        }
    }
}

