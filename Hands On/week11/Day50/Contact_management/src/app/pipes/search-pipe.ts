import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search',
  pure:false
})
export class SearchPipe implements PipeTransform {

  transform(contacts: any[], searchText: string): any[] {

    if (!contacts || !searchText) return contacts;

    searchText = searchText.toLowerCase();

    return contacts.filter(contact =>
      contact.name.toLowerCase().includes(searchText) ||
      contact.email.toLowerCase().includes(searchText)
    );
  }

}
