import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Contactservice {

  private apiUrl = 'https://localhost:7266/api/Contact';

  constructor(private http: HttpClient) {}

  getContacts() {
    return this.http.get<Contact[]>(this.apiUrl);
  }

  getContact(id: number) {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`);
  }

  addContact(contact: Contact) {
    return this.http.post<Contact>(this.apiUrl, contact);
  }

  updateContact(contact: Contact) {
    return this.http.put<Contact>(
      `${this.apiUrl}/${contact.contactId}`,
      contact
    );
  }

  deleteContact(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}