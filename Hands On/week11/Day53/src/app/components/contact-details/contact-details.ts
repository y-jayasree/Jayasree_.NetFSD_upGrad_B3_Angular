import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable, EMPTY, Subject } from 'rxjs';
import { switchMap, catchError, takeUntil } from 'rxjs/operators';
import { Contactservice } from '../../services/contactservice';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-details',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './contact-details.html',
  styleUrl: './contact-details.css',
})
export class ContactDetails implements OnInit, OnDestroy {

  // The contact$ Observable drives the template via async pipe —
  // no manual subscription or component state variable needed.
  contact$!: Observable<Contact>;

  errorMessage = '';

  private destroy$ = new Subject<void>();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contactService: Contactservice
  ) {}

  ngOnInit(): void {
    /**
     * switchMap: when the route :id param changes, the previous HTTP request
     * is automatically cancelled and a new one is started.
     * This correctly handles browser back/forward navigation.
     */
    this.contact$ = this.route.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        return this.contactService.getContact(id).pipe(
          catchError(err => {
            this.errorMessage = `Could not load contact #${id}. It may not exist.`;
            return EMPTY;  // Don't propagate the error; just stop the stream
          })
        );
      })
    );
  }

  onDelete(id: number): void {
    if (!confirm('Are you sure you want to delete this contact?')) { return; }

    this.contactService.deleteContact(id).pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => this.router.navigate(['/contacts']),
      error: () => { this.errorMessage = 'Delete failed. Please try again.'; }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
