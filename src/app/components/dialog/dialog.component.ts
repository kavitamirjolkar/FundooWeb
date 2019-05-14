import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotesondashboardComponent, DialogData } from '../notesondashboard/notesondashboard.component';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  note:any;
  constructor(public dialogRef: MatDialogRef<NotesondashboardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
      console.log(data);
    this.note=data.note;
    console.log(this.note);
    }

  ngOnInit() {
  }
  onNoClick()
   {
    this.dialogRef.close(this.note);
   }
}
