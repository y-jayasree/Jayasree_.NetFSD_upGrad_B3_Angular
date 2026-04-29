import { Component, Input } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-details',
  standalone:true,
  imports: [CommonModule,FormsModule],
  templateUrl: './contact-details.html',
  styleUrl: './contact-details.css',
})
export class ContactDetails {
  @Input() contactId: number = 0;

  constructor(private contactService:Contactservice) {}

  get contact(): Contact | undefined {
    return this.contactService.getContactById(this.contactId);
  }
}
