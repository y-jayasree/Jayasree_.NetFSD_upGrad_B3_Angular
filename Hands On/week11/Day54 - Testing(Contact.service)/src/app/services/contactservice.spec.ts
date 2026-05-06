import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { Contactservice } from './contactservice';
import { Contact } from '../models/contact';

describe('Contactservice', () => {
  let service: Contactservice;
  let httpMock: HttpTestingController;

  const mockContacts: Contact[] = [
    {
      contactId: 1,
      name: 'John',
      email: 'john@test.com',
      phone: '1234567890',
      categoryId: 1
    },
    {
      contactId: 2,
      name: 'Jane',
      email: 'jane@test.com',
      phone: '9876543210',
      categoryId: 2
    }
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [Contactservice]
    });

    service = TestBed.inject(Contactservice);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch all contacts (GET)', () => {
    service.getContacts().subscribe((data) => {
      expect(data.length).toBe(2);
      expect(data).toEqual(mockContacts);
    });

    const req = httpMock.expectOne('https://localhost:7266/api/Contact');
    expect(req.request.method).toBe('GET');
    req.flush(mockContacts);
  });

  it('should fetch single contact (GET by id)', () => {
    service.getContact(1).subscribe((data) => {
      expect(data).toEqual(mockContacts[0]);
    });

    const req = httpMock.expectOne('https://localhost:7266/api/Contact/1');
    expect(req.request.method).toBe('GET');
    req.flush(mockContacts[0]);
  });

  it('should add contact (POST)', () => {
    const newContact: Contact = {
      contactId: 3,
      name: 'Sam',
      email: 'sam@test.com',
      phone: '1112223333',
      categoryId: 1
    };

    service.addContact(newContact).subscribe((data) => {
      expect(data).toEqual(newContact);
    });

    const req = httpMock.expectOne('https://localhost:7266/api/Contact');
    expect(req.request.method).toBe('POST');
    req.flush(newContact);
  });

  it('should update contact (PUT)', () => {
    const updatedContact: Contact = {
      ...mockContacts[0],
      name: 'Updated Name'
    };

    service.updateContact(updatedContact).subscribe((data) => {
      expect(data.name).toBe('Updated Name');
      expect(data.contactId).toBe(1);
    });

    const req = httpMock.expectOne(
      `https://localhost:7266/api/Contact/${updatedContact.contactId}`
    );

    expect(req.request.method).toBe('PUT');
    req.flush(updatedContact);
  });

  it('should delete contact (DELETE)', () => {
    service.deleteContact(1).subscribe((data) => {
      expect(data).toBeNull();
    });

    const req = httpMock.expectOne('https://localhost:7266/api/Contact/1');
    expect(req.request.method).toBe('DELETE');
    req.flush(null);
  });
});