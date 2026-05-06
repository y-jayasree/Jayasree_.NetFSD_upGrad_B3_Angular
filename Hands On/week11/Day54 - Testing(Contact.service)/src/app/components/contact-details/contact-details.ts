import { Component } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact-details.html',
  styleUrl: './contact-details.css',
})
export class ContactDetails {

  contacts: Contact[] = [];

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    categoryId: 0
  };

  constructor(private service: Contactservice) {}

  ngOnInit() {
    this.getAllContacts();
  }

  // GET
  getAllContacts() {
    this.service.getContacts().subscribe({
      next: (data) => this.contacts = data,
      error: () => alert("Failed to fetch contacts")
    });
  }

  // ADD
  add() {
    this.service.addContact(this.contact).subscribe({
      next: () => {
        alert("Contact added");
        this.getAllContacts();
        this.reset();
      },
      error: () => alert("Add failed")
    });
  }

  // UPDATE
  update() {
    this.service.updateContact(this.contact).subscribe({
      next: () => {
        alert("Updated successfully");
        this.getAllContacts();
        this.reset();
      },
      error: () => alert("Update failed")
    });
  }

  // DELETE
  delete(id: number) {
    this.service.deleteContact(id).subscribe({
      next: () => {
        alert("Deleted");
        this.getAllContacts();
      },
      error: () => alert("Delete failed")
    });
  }

  // EDIT 
  edit(c: Contact) {
    this.contact = { ...c };
  }

  // RESET FORM
  reset() {
    this.contact = {
      contactId: 0,
      name: '',
      email: '',
      phone: '',
      categoryId: 0
    };
  }
}
