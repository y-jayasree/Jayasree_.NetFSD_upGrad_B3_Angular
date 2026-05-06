import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css'
})
export class AddContact {

  /**
   * Reactive Form: all validation rules declared here,
   * not inside the template.
   */
  contactForm = new FormGroup({
    name:       new FormControl('', [Validators.required, Validators.minLength(2)]),
    email:      new FormControl('', [Validators.required, Validators.email]),
    phone:      new FormControl('', [Validators.required, Validators.pattern(/^\d{10}$/)]),
    categoryId: new FormControl(1,  [Validators.required, Validators.min(1)])
  });

  isSubmitting = false;
  errorMessage = '';

  constructor(
    private contactService: Contactservice,
    private router: Router
  ) {}

  get f() { return this.contactForm.controls; }

  onSubmit(): void {
    if (this.contactForm.invalid) {
      this.contactForm.markAllAsTouched();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';

    const contact: Contact = {
      contactId: 0,
      name:       this.contactForm.value.name!,
      email:      this.contactForm.value.email!,
      phone:      this.contactForm.value.phone!,
      categoryId: this.contactForm.value.categoryId!
    };

    /**
     * addContact() returns an Observable.
     * The service's tap() reactively updates the BehaviorSubject,
     * so the contact list refreshes automatically when we navigate back.
     */
    this.contactService.addContact(contact).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.router.navigate(['/contacts']);
      },
      error: (err) => {
        this.isSubmitting = false;
        this.errorMessage = 'Failed to add contact. Please check your input and try again.';
      }
    });
  }
}
