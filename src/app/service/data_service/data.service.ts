import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private messageSource = new BehaviorSubject<boolean>(false);
  private msg = new BehaviorSubject<string>("msg");
  currentMessage = this.messageSource.asObservable();
  currentmsg=this.msg.asObservable();
  constructor() { }
  changeMessage(message: boolean) {
    console.log('message in data service',message);
    
    this.messageSource.next(message)
  }
  changeMsg(view: string) {
    console.log('data service',view);
    
    this.msg.next(view)
  }
}
