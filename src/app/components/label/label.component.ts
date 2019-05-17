import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotesService } from 'src/app/service/notes.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.css']
})
export class LabelComponent implements OnInit {
  notesLabel:any;
  userId: any;
  @Output() AfterAddEvent = new EventEmitter();
  constructor(public dialogRef: MatDialogRef<LabelComponent>,private notesService: NotesService,@Inject(MAT_DIALOG_DATA) public data: any) { }
  label = new FormControl('');
  ngOnInit() {
    this.userId = localStorage.getItem('UserID')
    this.notesLabel=this.data
  }
  close() {
    
    var data ={
      "Label":this.label.value,
      "UserId":this.userId
    }
    console.log(data);
    if(this.label.value !=""){
    this.notesService.AddLabels(data).subscribe(result=>
      console.log(data) 
      
     )
    this.dialogRef.close(data);
    this.AfterAddEvent.emit({});
  }
}
  update(label)
  {
    console.log(label.label,"jgkldfgkdf");
    this.notesService.updateLabel(label.id,label.label).subscribe(result =>
      console.log(result)
      )
  }
  delete(label)
  {
    this.notesService.deletelabel(label.id).subscribe(result =>
      console.log(result) )     
  }  
}