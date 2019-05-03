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
 
  list=[
    {name:"Notes",icon:"lightbulb_outline"},
    {name:"Reminders",icon:"notifications_none"}
   ]

   lables=[
    {name:"Edit labels",icon:"create"}
   ]
   operation=[
    {name:"Archive",icon:"archive"},
    {name:"Trash",icon:"delete_outline"}
   ]
  islist: boolean=false;
  isClicked: boolean;
  notesLabel: any;
  token: string;
  payLoad: any;
 
  constructor(private router: Router, private service: UserService,changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,private data: DataService,public dialog: MatDialog,private notes:NotesService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.token = localStorage.getItem('token');
    this.payLoad = jwt_decode(this.token);
    this.notes.getlabels(this.payLoad.UserID).subscribe(responselabels => {
      this.notesLabel = responselabels['result'];
      console.log(this.notesLabel)
    }, err => {
      console.log(err);
    })
   }
  
   
   ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  ngOnInit() {
    
    this.data.currentMessage.subscribe(message => this.message = message);
    islist: true;
    isClicked: false;

    
  }
  shouldRun =true;

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  
  onClick(){
    this.router.navigate(['/home/notes']);
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
        width: '600px',
        data: this.notesLabel
  
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log(result, "dash");
        if (result.labels != '' && result.labels != null) {
          this.notes.AddLabels(result).subscribe((data: any) => {
            console.log(data)
          }, err => {
            console.log(err);
      
          });
        }
      })
    
}


}