import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';


@Injectable({
  providedIn: 'root',
})
export class Contactservice {
  private contacts:Contact[]=[
    { id: 1, name: 'Jaya', email: 'jaya@gmail.com', phone: '9999999999' },
    { id: 2, name: 'smith', email: 'smith@gmail.com', phone: '8888888888' },
    { id: 3, name: 'Allen', email: 'allen@gmail.com', phone: '9988776655' },
    { id: 4, name: 'John', email: 'jon@gmail.com', phone: '5566778899' }
  ];

//get all contacts
getContacts():Contact[]{
  return this.contacts;
}
addContact(contact:Contact):void{
  this.contacts.push(contact);
}
getContactById(id:number):Contact|undefined{
  return this.contacts.find(c=>c.id==id);
}
}