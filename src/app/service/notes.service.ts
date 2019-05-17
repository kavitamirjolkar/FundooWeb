import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Notes } from '../models/notes.model';
import{environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  BaseURI=environment.BaseURI;
  constructor(private http: HttpClient) { }
  addNotes(url,notes)
  {
    console.log(notes);
   return  this.http.post(this.BaseURI+'notes/'+url,notes);
  }
  getNotes()
  {
    return this.http.get<Notes[]>(this.BaseURI+'notes/allnotes');
  }
  getNotesById(UserId)
  {
   
    return this.http.get<Notes[]>(this.BaseURI+'notes/notesbyId',{ params:{
      userId:UserId
      } });
  }
  deleteNote(result){
    return this.http.delete(this.BaseURI+'notes/note/'+result.id,result);
  }
  updateNotes(result)
  {
    return this.http.put(this.BaseURI+'notes/notes/'+result.id,result);
  }

  reminders(UserId)
  {
    return this.http.get(this.BaseURI+'notes/reminder/'+UserId);
  }
  imageOnNote(path,id)
  {
return this.http.post(this.BaseURI+'notes/image/'+id,path
 ,{responseType:'text'});
  }

  archive(userId)
  {
    return this.http.get(this.BaseURI+'notes/archive/'+ userId);
  }

  getlabels(userId){
    return this.http.get(this.BaseURI+'notes/label/'+userId);
    
    }
    AddLabels(label)
  {
    return this.http.post(this.BaseURI+'notes/label', label);
  }
  deletelabel(lableid)
  {
    return this.http.delete(this.BaseURI+ 'notes/label/' + lableid);
    
  }

  updateLabel(id,label)
  {
    console.log(label,"ts")
    return this.http.put(this.BaseURI+'notes/label/' + id,{
      "Label":label
    });
  }

    AddNotesLabels(notesLabel){
      return this.http.post(this.BaseURI+'notes/notelabel',notesLabel);
    }
    getNotesLabels(userid)
  {
    return this.http.get(this.BaseURI +'notes/notelabel/'+userid);
    
  }

  deleteNotelabel(lableid)
  {
    return this.http.delete(this.BaseURI+ 'notes/notelabel/'+lableid);
    
  }

  addcollaborator(data){
    return this.http.post(this.BaseURI+'notes/collaborator',data);
  }

  removeCollaborator(id){
   return this.http.delete(this.BaseURI+'notes/collaborator/'+id);
  }
  getCollaboratorNote(receiverEmail){
    return this.http.get(this.BaseURI+'notes/collaborator/'+receiverEmail);
  }
}