import { Component, OnInit } from '@angular/core';
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
  archiveCards: [];
  userId:any;
  archive='archive'

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
  this.getAllArchivecards();
}

}
