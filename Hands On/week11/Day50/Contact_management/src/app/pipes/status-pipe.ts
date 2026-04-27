import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'status',
  pure:false
})
export class StatusPipe implements PipeTransform {
  transform(value:boolean): string {
    return value?'Active':'Inactive';
  }
}
