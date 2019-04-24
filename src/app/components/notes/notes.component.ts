import { Component, OnInit, Input,Output,EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/service/notes.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  addNotes: FormGroup;
  token_id:any;
  @Output() cardUpdate = new EventEmitter();
  constructor(private router: Router, public service: NotesService) { }
  

  title=new FormControl('',[Validators.required]);
  take_a_note = new FormControl('',[Validators.required]);
  
  ngOnInit() {
  var token=localStorage.getItem('token');
var jwt_token=jwt_decode(token);
console.log(jwt_token.UserID);
localStorage.setItem("UserID",jwt_token.UserID)
 this.token_id=localStorage.getItem("UserID")
console.log(this.token_id);

  }

  AddNotes() {
    var notes:Notes={
             UserId :this.token_id,
            Title:this.title.value,
            Description:this.take_a_note.value          
          }
          if(this.title.value !="" && this.take_a_note.value!=""){
   this.service.addNotes('note',notes)
     .subscribe(data => {
       this.cardUpdate.emit();     
     });
    }
  }
}