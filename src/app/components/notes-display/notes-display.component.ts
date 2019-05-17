import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import { NotesService } from 'src/app/service/notes.service';
import * as jwt_decode from "jwt-decode";
@Component({
  selector: 'app-notes-display',
  templateUrl: './notes-display.component.html',
  styleUrls: ['./notes-display.component.css']
})
export class NotesDisplayComponent implements OnInit {
 userId:any
  notes: Notes[];
  @Input() search;
  @Input() noteCards = [];
  @Input() type;
  @Output() cardUpdate = new EventEmitter();
  @Input() cond;
  id: string;
  cards: any;
  constructor( private notesService: NotesService) { }

  ngOnInit() {
   this.userId = localStorage.getItem("UserId");
   var token=localStorage.getItem('token');
  var jwt_token=jwt_decode(token);
  localStorage.setItem("UserID",jwt_token.UserID)
   this.id=localStorage.getItem("UserID")
 this.getAllNotes();
 
}

getAllNotes(){
  this.notesService.getNotesById(this.id).subscribe(  
    data => {
      this.notes=data;
      this.noteCards=[];
      this.cards=this.notes;
      this.cards.forEach(element => {
        if(element.isArchive || element.isTrash){
          return;
        }
        else
        this.noteCards.push(element);       
      });
    }
),err=>{
         console.log(err);         
       };  
}

closed(event){
  this.getAllNotes();
  
}
update(event){
  this.getAllNotes();
}
}




