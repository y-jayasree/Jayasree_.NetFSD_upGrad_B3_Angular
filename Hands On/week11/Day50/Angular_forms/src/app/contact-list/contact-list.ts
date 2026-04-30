import { Component } from '@angular/core';
import { Contact } from '../models/contact.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-list',
  standalone:true,
  imports: [CommonModule,FormsModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts: Contact[] = [
    { contactId: 1, name: 'Asha', email: 'asha@gmail.com', phone: '9876543210', isActive: true },
    { contactId: 2, name: 'Ravi', email: 'ravi@gmail.com', phone: '9876543211', isActive: false }
  ];
}
