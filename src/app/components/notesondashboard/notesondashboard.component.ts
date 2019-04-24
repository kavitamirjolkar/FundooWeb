import { Component, OnInit,Input } from '@angular/core';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import { NotesService } from 'src/app/service/notes.service';
import { DataService } from 'src/app/service/data_service/data.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-notesondashboard',
  templateUrl: './notesondashboard.component.html',
  styleUrls: ['./notesondashboard.component.css']
})
export class NotesondashboardComponent implements OnInit {
  notes:Notes[];
  message:boolean;
  id:any;
  @Input() cardAdded;
  constructor(private router: Router, private notesService: NotesService,private data: DataService) { }

  main={
    grid:false,
    list:true
  }


  ngOnInit() {
  //   this.notesService.getNotes().subscribe(  
  //     data => {
  //       console.log(data);
  //       this.notes = data 
  //     }
  // ),err=>{
  //          console.log(err);         
  //        };  
  console.log('notes  '+this.notes);
  this.data.currentMessage.subscribe(message => {
    console.log('message in notes',message);

    this.main.grid=!message;
    this.main.list=message;
    
  });

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
    }
),err=>{
         console.log(err);         
       };  
  }
  // newMessage() {
  //   this.data.changeMessage(false);
  // } 

  
}