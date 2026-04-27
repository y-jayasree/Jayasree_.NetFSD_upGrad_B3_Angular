import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PhoneFormatPipe } from './pipes/phone-format-pipe';
import { SearchPipe } from './pipes/search-pipe';
import { StatusPipe } from './pipes/status-pipe';

@Component({
  selector: 'app-root',
  standalone:true,
  imports:[CommonModule,FormsModule,PhoneFormatPipe,SearchPipe,StatusPipe],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

  searchText = '';
  showCount = 5;

  contacts = [
    { name: 'John DOE', email: 'john@gmail.com', phone: '9876543210', status: true },
    { name: 'jane smITh', email: 'jane@gmail.com', phone: '9123456780', status: false },
    { name: 'AleX', email: 'alex@gmail.com', phone: '9988776655', status: true },
    { name: 'rAm', email: 'ram@gmail.com', phone: '9090909090', status: false },
    { name: 'sita', email: 'sita@gmail.com', phone: '8888888888', status: true },
    { name: 'kriSHna', email: 'krishna@gmail.com', phone: '7777777777', status: true },
    { name: 'arjun', email: 'arjun@gmail.com', phone: '6666666666', status: false },
    { name: 'MEEna', email: 'meena@gmail.com', phone: '5555555555', status: true },
    { name: 'rahul', email: 'rahul@gmail.com', phone: '4444444444', status: false },
    { name: 'kIraN', email: 'kiran@gmail.com', phone: '3333333333', status: true }
  ];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }

  showMore() {
    this.showCount = this.contacts.length;
  }

  showLess() {
    this.showCount = 5;
  }

}
