import { Component } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-contact',
  standalone:true,
  imports: [CommonModule,FormsModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
  contact:Contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };
constructor(private contactservice: Contactservice) {}

  addContact() {
    this.contactservice.addContact(this.contact);

    this.contact = { id: 0, name: '', email: '', phone: '' };
  }
}
