import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private messageSource = new BehaviorSubject<boolean>(false);
  currentMessage = this.messageSource.asObservable();
  constructor() { }
  changeMessage(message: boolean) {
    console.log('message in data service',message);
    
    this.messageSource.next(message)
  }
}
