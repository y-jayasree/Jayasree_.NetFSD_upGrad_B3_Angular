import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Observable, Subject, combineLatest, of } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  switchMap,
  startWith,
  map,
  catchError,
  takeUntil,
  tap
} from 'rxjs/operators';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css'
})
export class ContactList implements OnInit, OnDestroy {

  // ── Streams ──────────────────────────────────────────────
  filteredContacts$!: Observable<Contact[]>;
  isLoading = false;
  errorMessage = '';
  successMessage = '';

  // ── Search control ───────────────────────────────────────
  // debounceTime + distinctUntilChanged prevent excessive API/filter calls
  searchControl = new FormControl('');

  // ── Reactive Form for Add Contact ────────────────────────
  addForm = new FormGroup({
    name:       new FormControl('', [Validators.required, Validators.minLength(2)]),
    email:      new FormControl('', [Validators.required, Validators.email]),
    phone:      new FormControl('', [Validators.required, Validators.pattern(/^\d{10}$/)]),
    categoryId: new FormControl(1, Validators.required)
  });

  // Unsubscribe notifier – avoids manual subscription tracking
  private destroy$ = new Subject<void>();

  constructor(private contactService: Contactservice) {}

  ngOnInit(): void {
    this.loadContacts();
    this.setupFilterStream();
  }

  /**
   * Loads contacts from the API once; the BehaviorSubject in the service
   * keeps the UI in sync for all subsequent mutations.
   */
  private loadContacts(): void {
    this.isLoading = true;
    this.contactService.loadContacts().pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => { this.isLoading = false; },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = 'Failed to load contacts. Please try again.';
      }
    });
  }

  /**
   * Combines the live contacts$ stream with the search input stream.
   * - debounceTime(300)      : waits 300ms after the user stops typing
   * - distinctUntilChanged() : skips emission if value hasn't changed
   * - map/filter             : transforms and filters the contact array
   */
  private setupFilterStream(): void {
    const search$ = this.searchControl.valueChanges.pipe(
      startWith(''),
      debounceTime(300),
      distinctUntilChanged(),
      map(term => (term ?? '').toLowerCase().trim())
    );

    this.filteredContacts$ = combineLatest([
      this.contactService.contacts$,
      search$
    ]).pipe(
      map(([contacts, term]) =>
        !term
          ? contacts
          : contacts.filter(c =>
              c.name.toLowerCase().includes(term) ||
              c.email.toLowerCase().includes(term) ||
              c.phone.includes(term)
            )
      )
    );
  }

  /**
   * Adds a contact via the service.
   * The service's tap() operator updates the BehaviorSubject reactively,
   * so the template re-renders automatically via async pipe — no reload needed.
   */
  onAddContact(): void {
    if (this.addForm.invalid) { return; }

    const payload: Contact = {
      contactId: 0,
      name:       this.addForm.value.name!,
      email:      this.addForm.value.email!,
      phone:      this.addForm.value.phone!,
      categoryId: this.addForm.value.categoryId!
    };

    this.contactService.addContact(payload).pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => {
        this.successMessage = `✓ Contact "${payload.name}" added successfully.`;
        this.addForm.reset({ categoryId: 1 });
        setTimeout(() => this.successMessage = '', 3000);
      },
      error: () => {
        this.errorMessage = 'Failed to add contact. Please try again.';
      }
    });
  }

  /**
   * Deletes a contact; the service's tap() removes it from the stream,
   * and the async pipe updates the view automatically.
   */
  onDelete(id: number): void {
    this.contactService.deleteContact(id).pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => {
        this.successMessage = '✓ Contact deleted.';
        setTimeout(() => this.successMessage = '', 3000);
      },
      error: () => { this.errorMessage = 'Delete failed.'; }
    });
  }

  // Convenience getter for template access to form controls
  get f() { return this.addForm.controls; }

  ngOnDestroy(): void {
    // Complete all subscriptions to prevent memory leaks
    this.destroy$.next();
    this.destroy$.complete();
  }
}
