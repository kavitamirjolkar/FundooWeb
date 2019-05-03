import { Component, OnInit } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.css']
})
export class TrashComponent implements OnInit {
  cards;
  trashCards=[];
  token:any;
  decodedToken : any;
  trash='trash'
  constructor(private notes:NotesService) { }

  ngOnInit() {
    this.token = localStorage.getItem('token')
   this.decodedToken =  jwt_decode(this.token)
   this.getAllTrashcards()
  }
  getAllTrashcards(){
    console.log("archive");
    this.notes.getNotesById(this.decodedToken.UserID).subscribe(data =>{
      console.log(data);
      
      this.cards=data;
      this.cards.forEach(element => {



        if(element.isTrash){
          this.trashCards.push(element);
        }
     
      });
      console.log(this.trashCards);
      

  })
}
DeletedNotes($event)
{
  this.getAllTrashcards()
}
}
