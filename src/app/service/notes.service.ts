import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Notes } from '../models/notes.model';
import{environment} from "../../environments/environment";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  BaseURI=environment.BaseURI;
  constructor(private http: HttpClient) { }
  addNotes(url,notes)
  {
    console.log(notes);
   return  this.http.post(this.BaseURI+'/notes/'+url,notes);
  }
  getNotes()
  {
    return this.http.get<Notes[]>(this.BaseURI+'/notes/allnotes');
  }
  getNotesById(UserId)
  {
    return this.http.get<Notes[]>(this.BaseURI+'/notes/notesbyId',{ params:{
      userId:UserId
      } });
  }

  deleteNote(noteId:any): Observable<number>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.BaseURI+'/notes/'+noteId,httpOptions);
  }
}
