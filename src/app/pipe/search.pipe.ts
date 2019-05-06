import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  
    transform(value: any, args?: any): any {
      if(!value)  return null;
     if(!args) return value;
  
     return value.filter(Array => Array.title.toLowerCase().indexOf(args.toLowerCase()) !==-1 || Array.description.toLowerCase().toLowerCase().indexOf(args.toLowerCase()) !==-1)
    }
  
  }


