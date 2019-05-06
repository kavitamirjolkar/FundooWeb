import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-collaboration',
  templateUrl: './collaboration.component.html',
  styleUrls: ['./collaboration.component.css']
})
export class CollaborationComponent implements OnInit {
  firstname: string;
  lastname: string;
  email: string;

  constructor(public dialogRef: MatDialogRef<CollaborationComponent>, private notes: NotesService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.firstname = localStorage.getItem("firstname");
    this.lastname = localStorage.getItem("lastname");
    this.email = localStorage.getItem("email");

  }

}
