import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.css']
})
export class ArchiveComponent implements OnInit {
  token: string;
  decodedToken: any;
  archiveCards: any;
  userId:any;
  archive='archive'
  @Output() cardUpdate = new EventEmitter();
  constructor(private notesService:NotesService) { }

  ngOnInit() {
    this.userId = localStorage.getItem("UserID")
    this.getAllArchivecards()
  }
  
  getAllArchivecards(){
    
    this.notesService.archive(this.userId).subscribe(data =>{
      console.log(data,"archivee");
      this.archiveCards=data['result'];
      console.log(this.archiveCards)
  },err =>
  {
    console.log(err,"from archive");
    
  })
}

Archived($event){
  console.log("archive event");
  
  this.getAllArchivecards();
}
}
