using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal interface IContactService
    {
        // Add new contact
        void AddContact(Contact contact);
        // Update existing contact
        void UpdateContact(Contact contact);
        //delete contact by id
        void DeleteContact(int Id);
        // Get all contacts
        List<Contact> GetAllContacts();
    }
}
