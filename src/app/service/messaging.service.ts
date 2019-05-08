import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import * as firebase from 'firebase';
import 'firebase/messaging';

@Injectable({
  providedIn: 'root'
})
export class MessagingService {
  currentMessage = new BehaviorSubject(null);
  messaging;
  constructor() {
    firebase.initializeApp({
      'messagingSenderId': '1066879774612'
      });
      this.messaging = firebase.messaging();
      
   }
   getPermission() {
    this.messaging.requestPermission()
    .then(() => {
    return this.messaging.getToken()
    })
    .then(token => {
    console.log(token)
    })
    .catch((err) => {
    console.log('Unable to get permission to notify.', err);
    });
    }

    receiveMessage() {
      this.messaging.onMessage((payload) => {
      console.log("Message received. ", payload);
      this.currentMessage.next(payload)
      });
      }

}
