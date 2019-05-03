import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/service/notes.service';

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrls: ['./reminder.component.css']
})
export class ReminderComponent implements OnInit {
  userId:any
  reminderCards: any;
  constructor(private notesService:NotesService) {
    this.userId = localStorage.getItem("UserID");
   }

  ngOnInit() {
    this.reminder();
  }
reminder(){
  this.notesService.reminders(this.userId).subscribe(data =>{
    console.log(data);
    
    this.reminderCards=data["result"];
    console.log(this.reminderCards)
  },err =>{
    console.log(err);
  }
    )
}
}
