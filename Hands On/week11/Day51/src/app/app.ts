import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AddContact } from './components/add-contact/add-contact';
import { ContactList } from './components/contact-list/contact-list';
import { ContactDetails } from './components/contact-details/contact-details';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet,FormsModule,CommonModule,AddContact,ContactList,ContactDetails,RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('contact-app');
}
