import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/service/notes.service';
import { DataService } from 'src/app/service/data_service/data.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  userid: string;
  
  noteCards=[];
  cards:any;
  searchText:string=''
  constructor(private notes:NotesService,public data:DataService) { }

  ngOnInit() {
    this.userid = localStorage.getItem("UserID")
    this.data.currentmsg.subscribe(response => {
      this.searchText=response;
      this.getallNotes();
  })

}
getallNotes(){
  this.notes.getNotesById(this.userid).subscribe(data =>{
    this.noteCards=[];
    this.cards=data;
  },err=>{
    console.log(err);
    
  })
}
}

