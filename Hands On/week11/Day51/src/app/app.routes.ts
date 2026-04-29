import { Routes } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { AddContact } from './components/add-contact/add-contact';
import { ContactDetails } from './components/contact-details/contact-details';

export const routes: Routes = [
    {path:'contacts',component:ContactList},
    {path:'add-contact',component:AddContact},
    {path:'contact/:id',component:ContactDetails}

];
