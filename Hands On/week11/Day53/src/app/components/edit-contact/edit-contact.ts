import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Subject, EMPTY } from 'rxjs';
import { switchMap, catchError, takeUntil } from 'rxjs/operators';
import { Contactservice } from '../../services/contactservice';

@Component({
  selector: 'app-edit-contact',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './edit-contact.html',
  styleUrl: './edit-contact.css'
})
export class EditContact implements OnInit, OnDestroy {

  editForm = new FormGroup({
    contactId:  new FormControl<number>(0),
    name:       new FormControl('', [Validators.required, Validators.minLength(2)]),
    email:      new FormControl('', [Validators.required, Validators.email]),
    phone:      new FormControl('', [Validators.required, Validators.pattern(/^\d{10}$/)]),
    categoryId: new FormControl(1,  [Validators.required, Validators.min(1)])
  });

  isLoading   = true;
  isSubmitting = false;
  errorMessage = '';

  private destroy$ = new Subject<void>();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contactService: Contactservice
  ) {}

  ngOnInit(): void {
    /**
     * switchMap on route params: if the user navigates to a different
     * contact's edit page, the previous request is cancelled automatically.
     */
    this.route.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        return this.contactService.getContact(id).pipe(
          catchError(() => {
            this.errorMessage = 'Failed to load contact. Redirecting…';
            setTimeout(() => this.router.navigate(['/contacts']), 2000);
            return EMPTY;
          })
        );
      }),
      takeUntil(this.destroy$)
    ).subscribe(contact => {
      // Patch the reactive form with API data
      this.editForm.patchValue(contact);
      this.isLoading = false;
    });
  }

  get f() { return this.editForm.controls; }

  onSubmit(): void {
    if (this.editForm.invalid) {
      this.editForm.markAllAsTouched();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage  = '';

    this.contactService.updateContact(this.editForm.getRawValue() as any).pipe(
      takeUntil(this.destroy$)
    ).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.router.navigate(['/contacts']);
      },
      error: () => {
        this.isSubmitting = false;
        this.errorMessage = 'Update failed. Please try again.';
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
