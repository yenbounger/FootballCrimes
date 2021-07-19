import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'list'
})
export class ListPipe implements PipeTransform {

  transform(value: any[], ...args: unknown[]): unknown {
    return value.join(", ");
  }

}
