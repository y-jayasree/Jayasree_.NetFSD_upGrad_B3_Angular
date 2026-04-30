import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from './login/login';
import { CommonModule } from '@angular/common';
import { EmployeePipe } from './employee-pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContactList } from './contact-list/contact-list';
import { TemplateForm } from './template-form/template-form';
import { ReactiveForm } from './reactive-form/reactive-form';


@Component({
  selector: 'app-root',
  standalone:true,
  // imports: [RouterOutlet, Login,EmployeePipe,CommonModule,FormsModule,ReactiveFormsModule],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,ContactList,TemplateForm,ReactiveForm      
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // protected readonly title = signal('my-project');
//   Employees=[
//     {name:'SCOTT',grade:1},
//     { name: 'ABRONS', grade: 2 },
//     { name: 'SMITH', grade: 3 },
//     { name: 'JAMES', grade: 4 },
//     { name: 'ADAM', grade: 1 },
//     { name: 'SATHYA', grade: 3 },
//     { name: 'MANEESH', grade: 4 },
//     { name: 'HANEESH', grade: 2 }
//   ];

//   customers = [
//   { id: '000001', name: 'Mary', surname: 'Walkor', card: '40139272' },
//   { id: '000002', name: 'William', surname: 'Gonzalez', card: '40139565' },
//   { id: '000003', name: 'Joseph', surname: 'Martin', card: '40135764' },
//   { id: '000004', name: 'James', surname: 'Jackson', card: '40132470' },
//   { id: '000005', name: 'Susan', surname: 'Harris', card: '40133248' },
//   { id: '000006', name: 'Dorothy', surname: 'Rodriguez', card: '40137812' },
//   { id: '000007', name: 'Thomas', surname: 'Williams', card: '40137659' },
//   { id: '000008', name: 'Margaret', surname: 'Gonzalez', card: '40138371' }
// ];

// gender=[
//   {name:'Jaya',gender:'F'},
//   {name:'Smith',gender:'M'},
//   {name:'Raji',gender:'F'},
//   {name:'King',gender:'M'},

// ]
}
