import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class Contactservice {

  private apiUrl = 'https://localhost:7266/api/Contact';

  // BehaviorSubject acts as the single source of truth for the contact list
  private contactsSubject = new BehaviorSubject<Contact[]>([]);

  // Public read-only Observable stream for components to consume
  contacts$ = this.contactsSubject.asObservable();

  constructor(private http: HttpClient) {}

  /**
   * Fetches all contacts from the API and pushes the result
   * into the contactsSubject so all subscribers react automatically.
   */
  loadContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.apiUrl).pipe(
      tap(contacts => this.contactsSubject.next(contacts)),
      catchError(err => {
        console.error('Error loading contacts:', err);
        return throwError(() => err);
      })
    );
  }

  /**
   * Returns a single contact by ID as an Observable stream.
   * Used in ContactDetails with route params via switchMap.
   */
  getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`).pipe(
      catchError(err => {
        console.error(`Error fetching contact ${id}:`, err);
        return throwError(() => err);
      })
    );
  }

  /**
   * Adds a new contact and reactively updates the contacts list
   * in-memory without an extra round-trip GET call.
   */
  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact).pipe(
      tap(newContact => {
        const current = this.contactsSubject.getValue();
        this.contactsSubject.next([...current, newContact]);
      }),
      catchError(err => {
        console.error('Error adding contact:', err);
        return throwError(() => err);
      })
    );
  }

  /**
   * Updates a contact and reactively replaces the record in-stream.
   */
  updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.apiUrl}/${contact.contactId}`, contact).pipe(
      tap(updated => {
        const current = this.contactsSubject.getValue();
        const index = current.findIndex(c => c.contactId === updated.contactId);
        if (index !== -1) {
          const updatedList = [...current];
          updatedList[index] = updated;
          this.contactsSubject.next(updatedList);
        }
      }),
      catchError(err => {
        console.error('Error updating contact:', err);
        return throwError(() => err);
      })
    );
  }

  /**
   * Deletes a contact and reactively removes it from the stream.
   */
  deleteContact(id: number): Observable<unknown> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(
      tap(() => {
        const current = this.contactsSubject.getValue();
        this.contactsSubject.next(current.filter(c => c.contactId !== id));
      }),
      catchError(err => {
        console.error(`Error deleting contact ${id}:`, err);
        return throwError(() => err);
      })
    );
  }
}
