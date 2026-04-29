import { Component } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
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
  id: number = 0;
  contact?: Contact;
  contacts:Contact[]=[];

  constructor(private contactService: Contactservice) {
    this.loadContacts();
  }
  loadContacts(){
    this.contacts=this.contactService.getContacts();
  }

  getContact() {
    this.contact = this.contactService.getContactById(this.id);
  }

}
