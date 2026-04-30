import { Component } from '@angular/core';
import { Contact } from '../models/contact.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-template-form',
  standalone: true,
  imports: [FormsModule, CommonModule],  
  templateUrl: './template-form.html',
})
export class TemplateForm {

  contacts: Contact[] = [];

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: true
  };

  addContact(form: any) {
    if (form.valid) {
      this.contact.contactId = this.contacts.length + 1;
      this.contacts.push({ ...this.contact });

      form.resetForm();
      this.contact.isActive = true;
    }
  }
}
