import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneFormat'
})
export class PhoneFormatPipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return '';

    return value.slice(0,3) + '-' +
           value.slice(3,6) + '-' +
           value.slice(6,10);
  }

}
