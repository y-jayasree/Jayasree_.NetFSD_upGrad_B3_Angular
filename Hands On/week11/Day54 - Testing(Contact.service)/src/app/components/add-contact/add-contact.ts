import { Component } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-contact.html',
})
export class AddContact {

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    categoryId: 1  
  };

  constructor(
    private service: Contactservice,
    private router: Router
  ) {}

  save() {
    this.service.addContact(this.contact).subscribe({
      next: () => {
        alert("Contact added successfully");

        this.contact = {
          contactId: 0,
          name: '',
          email: '',
          phone: '',
          categoryId: 1
        };

        this.router.navigate(['/contacts']);
      },
      error: (err) => {
        console.error(err);
        alert("Add failed");
      }
    });
  }
}
