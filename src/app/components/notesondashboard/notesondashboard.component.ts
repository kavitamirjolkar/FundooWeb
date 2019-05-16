import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import { NotesService } from 'src/app/service/notes.service';
import { DataService } from 'src/app/service/data_service/data.service';
import * as jwt_decode from "jwt-decode";
import { MatDialog } from '@angular/material';
import { DialogComponent } from '../dialog/dialog.component';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

// import { DialogComponent } from '../dialog/dialog.component';
export interface DialogData {
  description: any;
  title: any;
}
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
  @Input() noteCards;
  @Input() type;
  title: any;
  description: any;
  @Input() search;
  @Output() cardUpdate = new EventEmitter();
  @Input() cond;
  cards: any;
  userId: any;
  allLabels: any;
  notesLabels: any;
  collaborator:any;
  receiverEmail: string;
  constructor(private router: Router, private notesService: NotesService,private data: DataService,public dialog: MatDialog) { 
    this.userId = localStorage.getItem("UserID")
    this.notesService.getlabels(this.userId).subscribe(responselabels => {
      this.allLabels = responselabels['result'];
      console.log(this.allLabels, "all labels")
    }, err => {
      console.log(err);
    })

    this.notesService.getNotesLabels(this.userId).subscribe(response => {
      this.notesLabels = response['result'];
      console.log(this.notesLabels, "notes labels")
    }, err => {
      console.log(err);
    })

    this.notesService.getCollaboratorNote(this.receiverEmail).subscribe(response=>{
      this.collaborator=response;
      console.log(this.collaborator,"collaborator");
      
    },err=>{
      console.log(err);
      
    }
      )
     
  }

  main={
    grid:false,
    list:true
  }
 
  ngOnInit() { 
  console.log('notes  '+this.notes);
  this.data.currentMessage.subscribe(message => {
    console.log('message in notes',message);

    this.main.grid=!message;
    this.main.list=message;  
    //  this.getAllNotes(); 
  });

  // var token=localStorage.getItem('token');
  // var jwt_token=jwt_decode(token);
  // console.log(jwt_token.UserID);
  // localStorage.setItem("UserID",jwt_token.UserID)
   this.id=localStorage.getItem("UserID")
  console.log(this.id);
  this.receiverEmail=localStorage.getItem('receiverEmail')
  }
 
  getAllNotes()
  {
    this.id=localStorage.getItem("UserID")
    this.notesService.getNotesById(this.id).subscribe(  
      data => {
        console.log(data);
        this.notes=data;
        this.noteCards=[];
      this.cards=data;
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
  }
  openDialog(note): void {
    console.log(note);
    const dialogRef = this.dialog.open(DialogComponent, {

      data: {note}
    }
    );
    dialogRef.afterClosed().subscribe(result=>{    
      console.log(result.id);
      this.notesService.updateNotes(result).subscribe(reult=>
        {
          console.log(result);
          
        },err =>{
          console.log(err);         
        }
        )     
    })
  } 
  DeleteForever(note) {
console.log('all trash note',this.noteCards);

    this.notesService.deleteNote(note).subscribe(data => {
      console.log(note);
      this.cardUpdate.emit({})
    }, err => {
      console.log(err);
    })
  }
  Restore(card) {
    card.delete = false;
    card.isTrash = card.delete;
    this.notesService.updateNotes(card).subscribe(data => {
      console.log(data);
      this.cardUpdate.emit({})
    }, err => {
      console.log(err);
    })
  }

  updateCome(value) {
    this.cardUpdate.emit({});
  }
  removeReminder(note)
  {
    note.reminder=null;
    this.notesService.updateNotes(note).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }

  // removeCollab(id){
  //  this.notesService.removeCollaborator(id).subscribe(result=>
  //   {
  //     console.log(result);
      
  //   },err=>{
  //     console.log(err);
  //   }
  //   )
  // }
  remove(id) {
    console.log(id, "lable");
    this.notesService.deleteNotelabel(id).subscribe(result =>
       { 
      console.log(result);
    }, err => {
      console.log(err);
    })
  }
  pinnote(note)
  {
    note.isPin = true;
    note.isPin = note.isPin;
    this.notesService.updateNotes(note).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }

  unpinnote(note)
  {
    note.isPin = false;
    note.isPin = note.isPin;
    this.notesService.updateNotes(note).subscribe(data =>{
      console.log(data);
    },err =>{
      console.log(err);
    })
  }
  // update(value){
  //   console.log(value,'event');
  //   this.getAllNotes();
    
  // }
  // closed(value){
  //   console.log(value,"from take note");
  //   this.getAllNotes();
  // }
  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.noteCards, event.previousIndex, event.currentIndex);
  }
}