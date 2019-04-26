import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { NotesService } from 'src/app/service/notes.service';
import { Notes } from 'src/app/models/notes.model';

@Component({
  selector: 'app-iocns-on-note',
  templateUrl: './iocns-on-note.component.html',
  styleUrls: ['./iocns-on-note.component.css']
})
export class IocnsOnNoteComponent implements OnInit {
  notes: Notes[];
  @Input() card;
  selectedFile: File;
  constructor(public notesService: NotesService) { }
  ngOnInit() {
  }

  delete(card): void {
    console.log(card,"ndsbxfm");
  //   this.notesService.deleteNote(card.Id)
  //     .subscribe(data => {
  //        this.notes = this.notes.filter(u => u !== card);
  //     })
  //  };
}

onFileChanged(event) {
  this.selectedFile = event.target.files[0]
}

onUpload(){
  
}
}
