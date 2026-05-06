import { Routes } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { AddContact } from './components/add-contact/add-contact';
import { ContactDetails } from './components/contact-details/contact-details';
import { EditContact } from './components/edit-contact/edit-contact';
import { authGuard } from './Authguards/auth-guard';
import { Home } from './components/home/home';
import { Notfound } from './components/notfound/notfound';

export const routes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },

  { path: 'contacts', component: ContactList },

  { path: 'add-contact', component: AddContact, canActivate: [authGuard] },

  { path: 'contact/:id', component: ContactDetails, canActivate: [authGuard] },

  { path: 'edit/:id', component: EditContact },

  { path: '**', component: Notfound },

  { path:'home',component:Home}
];
