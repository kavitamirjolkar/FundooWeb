import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { NotesService } from 'src/app/service/notes.service';
import { Notes } from 'src/app/models/notes.model';
import { MatDialog, MatDialogConfig } from '@angular/material';

@Component({
  selector: 'app-iocns-on-note',
  templateUrl: './iocns-on-note.component.html',
  styleUrls: ['./iocns-on-note.component.css']
})
export class IocnsOnNoteComponent implements OnInit {
  notes: Notes[];
  @Input() card;
  @Input() type;
  @Output() update =new EventEmitter();
  @Output() setcolortoNote = new EventEmitter()
  selectedFile: File;
  userId: string;
  notesLabel: any;
  constructor(public notesService: NotesService,private dialog: MatDialog) { }
  ngOnInit() {
    this.userId = localStorage.getItem('UserID')
    this.notesService.getlabels(this.userId).subscribe(responselabels => {
      this.notesLabel = responselabels['result'];
      console.log(this.notesLabel)
    },err=>{
      console.log(err);
    })
  }

  setcolor(color: any,card) {
    if(card==undefined){
        this.setcolortoNote.emit(color)
    }
    else{
    console.log(card,"card")
    card.color = color;
    card.color = card.color;
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
    },err=>{
      console.log(err);
    })
  }
  }

  archive(card){
    card.setArchive = true;
    card.isArchive = card.setArchive;
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err=>{
      console.log(err);
    })
  }

  unArchive(card){
    card.setArchive = false;
    card.isArchive = card.setArchive;
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err=>{
      console.log(err);
    })
  }

  DeleteNote(card)
  {
    card.delete = true;
    card.IsTrash = card.delete;
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  LabelList(label)
  {
    console.log(label.id);
    console.log(this.card.id);
    this.userId = localStorage.getItem('UserID')
    var notesLabel = {
      "LableId":label.id,
      "NoteId":this.card.id,
      "UserId":this.userId
    }
    console.log(notesLabel);
    this.notesService.AddNotesLabels(notesLabel).subscribe(data => {
      console.log(data);
    },err =>{
      console.log(err);
    }
    )
  }


onFileChanged(event,card) {
  this.selectedFile = event.target.files[0];
  let uploadData=new FormData();
  uploadData.append('file',this.selectedFile,'file');
  console.log(uploadData,card.id);
  
  this.notesService.imageOnNote(uploadData,card.id).subscribe(data=>{
    console.log(data);
    localStorage.setItem('image',data)
  },err=>{
    console.log(err);
  }
    )
}

Today(card)
{
  var date = new Date();
  date.setHours(20,0,0)
  card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " +  date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
  this.notesService.updateNotes(card).subscribe(data =>{
    console.log(data);
    this.update.emit({});
  },err =>{
    console.log(err);
  })
}

Tomorrow(card)
  {
    var date = new Date();
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()+1) + " " +  date.getHours() + ":" + date.getMinutes();
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }

  nextWeek(card)
  {
    var date = new Date();
    date.setHours(8,0,0)
    card.reminder = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + (date.getDate()+7) + " " +  date.getHours() + ":" + date.getMinutes();
    this.notesService.updateNotes(card).subscribe(data =>{
      console.log(data);
      this.update.emit({});
    },err =>{
      console.log(err);
    })
  }


}