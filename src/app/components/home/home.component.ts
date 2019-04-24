import { UserService } from 'src/app/service/user.service';
import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { MediaMatcher } from '@angular/cdk/layout';
import { DataService } from 'src/app/service/data_service/data.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit,OnDestroy {
  message:boolean;
  userDetails;
  mobileQuery: MediaQueryList;
  
  private _mobileQueryListener: () => void;
 
  list=[
    {name:"Notes",route:"/notes",icon:"lightbulb_outline"},
    {name:"Reminders",route:"/reminder",icon:"notifications_none"}
   ]

   lables=[
    {name:"Edit lables",route:"",icon:"create"}
   ]
   operation=[
    {name:"Archive",route:"",icon:"archive"},
    {name:"Trash",route:"",icon:"delete_outline"}
   ]
  islist: boolean=false;
  isClicked: boolean;
 
  constructor(private router: Router, private service: UserService,changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,private data: DataService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
   }
   
   ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  ngOnInit() {
    // this.service.getUserProfile().subscribe(
    //   res => {
    //     this.userDetails = res;
    //   },
    //   err => {
    //     console.log(err);
    //   },
    // );

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
    this.router.navigate(['/user/home/notes']);
  }
  changeview() {
    this.islist=!this.islist;
    console.log(this.islist);
    this.data.changeMessage(this.islist);
    
    }
    
}