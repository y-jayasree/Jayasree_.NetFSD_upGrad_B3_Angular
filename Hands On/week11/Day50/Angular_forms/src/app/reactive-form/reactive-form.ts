import { Component } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reactive-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule], 
  templateUrl: './reactive-form.html',
  styleUrl: './reactive-form.css',
})
export class ReactiveForm {

  contacts: Contact[] = [];

  form: any;  

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({   
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      isActive: [true]
    });
  }

  submit() {
    if (this.form.valid) {
      this.contacts.push({
        contactId: this.contacts.length + 1,
        ...this.form.value
      });

      this.form.reset({ isActive: true });
    }
  }
}
