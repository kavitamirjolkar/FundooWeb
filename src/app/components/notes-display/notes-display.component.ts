import { Component, OnInit } from '@angular/core';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-notes-display',
  templateUrl: './notes-display.component.html',
  styleUrls: ['./notes-display.component.css']
})
export class NotesDisplayComponent implements OnInit {
  cardAdded;
  constructor( ) { }

  ngOnInit() {
   
}
updateCards(){
  this.ngOnInit();
}
  }



