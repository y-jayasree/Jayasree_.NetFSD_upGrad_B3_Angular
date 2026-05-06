import { Component, OnInit } from '@angular/core';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-contact',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './edit-contact.html',
})
export class EditContact implements OnInit {

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    categoryId: 1
  };

  constructor(
    private service: Contactservice,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.service.getContact(id).subscribe({
      next: (data) => this.contact = data,
      error: (err) => {
        console.error(err);
        alert('Could not load contact. Returning to list.');
        this.router.navigate(['/contacts']);
      }
    });
  }

  update() {
    this.service.updateContact(this.contact).subscribe({
      next: () => {
        alert('Updated successfully');
        this.router.navigate(['/contacts']);
      },
      error: (err) => {
        console.error(err);
        alert('Update failed');
      }
    });
  }

  cancel() {
    this.router.navigate(['/contacts']);
  }
}