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
  console.log(jwt_token.UserID);
  localStorage.setItem("UserID",jwt_token.UserID)
   this.id=localStorage.getItem("UserID")
  console.log(this.id);
  
  this.notesService.getNotesById(this.id).subscribe(  
    data => {
      console.log(data);
      this.notes=data;
      this.noteCards=[];
      this.cards=this.notes;
      console.log(this.cards);
      this.cards.forEach(element => {
        if(element.isArchive || element.isTrash){
          return;
        }
        else
        this.noteCards.push(element);

        
      });
      console.log(this.cards);
    }
),err=>{
         console.log(err);         
       };  
  //  this.getAllNotes();
}
// getAllNotes()
// {
//   this.notesService.getNotesById(this.userId).subscribe(  
//     data => {
//       console.log(data);
//       this.notes=data;
//     }
// ),err=>{
//          console.log(err);         
//        };
// }


}




