import { UserService } from 'src/app/service/user.service';
import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { MediaMatcher } from '@angular/cdk/layout';
import { DataService } from 'src/app/service/data_service/data.service';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { LabelComponent } from '../label/label.component';
import { NotesService } from 'src/app/service/notes.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit,OnDestroy {
  message:boolean;
  userDetails;
  headName="FundooNotes";
  mobileQuery: MediaQueryList;
  
  private _mobileQueryListener: () => void;
  islist: boolean=false;
  isClicked: boolean;
  notesLabel: any;
  token: string;
  payLoad: any;
  value;
  photo;
  selectedFile: File;
  email: string;
  Email: string;
  FirstName: string;
  constructor(private router: Router, private service: UserService,changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,private data: DataService,public dialog: MatDialog,private notes:NotesService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    
    this.token = localStorage.getItem('token');
    this.payLoad = jwt_decode(this.token);
    
   }
  
   
   ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  ngOnInit() {
    this.photo=localStorage.getItem('profile');
  
    this.Email = localStorage.getItem("Email");
    this.FirstName = localStorage.getItem("FirstName");
    
    this.data.currentMessage.subscribe(message => this.message = message);
    islist: true;
    isClicked: false;
    this.email = localStorage.getItem("Email")
    this.getLabels();
  }
  
  shouldRun =true;

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  
  onClick(){
    this.router.navigate(['/home/notes']);
  }
  lookfor(){
    this.data.changeMsg(this.value)
      }
      goSearch(){
        this.router.navigate(['/home/search'])
      }

  refresh(){
    location.reload();
  }
  changeview() {
    this.islist=!this.islist;
    console.log(this.islist);
    this.data.changeMessage(this.islist);
    
    }

    openDialog(): void {
      const dialogConfig = new MatDialogConfig();
      let dialogRef = this.dialog.open(LabelComponent, {
       
        data: this.notesLabel
  
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log(result.result, "dash");
        if (result.label != '' && result.label != null) {
          this.notes.AddNotesLabels(result).subscribe((data: any) => {
            console.log(data)
           
          }, err => {
            console.log(err);
      
          });
        }
      })
    
}

getLabels(){
  this.notes.getlabels(this.payLoad.UserID).subscribe(responselabels => {
    this.notesLabel = responselabels['result'];
   
  }, err => {
    console.log(err);
  })
}
add($event){
  this.getLabels();
}
onFileChanged(event) {
  this.selectedFile = event.target.files[0];
  let uploadData=new FormData();
  uploadData.append('file',this.selectedFile,'file');
  console.log(uploadData);
  
  this.service.profilePicture(uploadData,this.email).subscribe(data=>{
    let obj=JSON.parse(data)
    localStorage.setItem('profile',obj.result)
  },err=>{
    console.log(err);
  }
    )
}  
}