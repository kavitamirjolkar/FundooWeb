import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Notes } from 'src/app/models/notes.model';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})

export class NotesComponent implements OnInit {
  addNotes: FormGroup;
  token_id: any;


  noteColor: any;
  notes: Notes[];
  noteCards: any[];
  cards: Notes;
  constructor(private router: Router, public service: NotesService) { }

  title = new FormControl('', [Validators.required]);
  take_a_note = new FormControl('', [Validators.required]);
  @Output() AferCloseEvent = new EventEmitter();
  ngOnInit() {
    this.token_id = localStorage.getItem("UserID")

  }

  setcolor($event) {
    console.log($event, "color")
    this.noteColor = $event
  }
  AddNotes() {
    var notes: Notes = {
      UserId: this.token_id,
      Title: this.title.value,
      Description: this.take_a_note.value,
      Color: this.noteColor

    }
    if (this.title.value != "" && this.take_a_note.value != "") {
      this.service.addNotes('note', notes)
        .subscribe(data => {
          this.title.reset();
          this.take_a_note.reset();
          this.AferCloseEvent.emit({});
        });
    }
  }
}