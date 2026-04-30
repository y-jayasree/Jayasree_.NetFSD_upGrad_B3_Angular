import { Component, OnInit } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact-list.html',
})
export class ContactList implements OnInit {

  contacts: Contact[] = [];

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    categoryId: 1
  };

  isEditMode: boolean = false;

  constructor(private service: Contactservice) {}

  ngOnInit() {
    this.getAllContacts();
  }

  getAllContacts() {
    this.service.getContacts().subscribe({
      next: (data) => {
        console.log('GET:', data);
        this.contacts = data;
      },
      error: (err) => console.error('GET ERROR:', err)
    });
  }

  addContact() {
    this.service.addContact(this.contact).subscribe({
      next: () => {
        alert('Contact Added');
        this.getAllContacts();
        this.resetForm();
      },
      error: (err) => {
        console.error('ADD ERROR:', err);
        alert('Add failed - check console');
      }
    });
  }

  selectContact(c: Contact) {
    this.contact = { ...c };
    this.isEditMode = true;
  }

  updateContact() {
    this.service.updateContact(this.contact).subscribe({
      next: () => {
        alert('Updated successfully');
        this.getAllContacts();
        this.resetForm();
      },
      error: (err) => {
        console.error('UPDATE ERROR:', err);
        alert('Update failed');
      }
    });
  }

  delete(id: number) {
    this.service.deleteContact(id).subscribe({
      next: () => {
        alert('Deleted');
        this.getAllContacts();
      },
      error: (err) => console.error('DELETE ERROR:', err)
    });
  }

  resetForm() {
    this.contact = {
      contactId: 0,
      name: '',
      email: '',
      phone: '',
      categoryId: 1
    };
    this.isEditMode = false;
  }
}