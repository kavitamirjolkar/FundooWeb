import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../service/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { AuthService, FacebookLoginProvider, GoogleLoginProvider, LinkedinLoginProvider } from 'angular-6-social-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  formModel = {
    UserName: '',
    Password: ''
  }
  userId: string;
  token: string;
  payLoad: any;
  constructor(private service: UserService, private router: Router, private toastr: ToastrService,private socialAuthService: AuthService) { }

  
  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (result: any) => {
        console.log(result,"98459hs");
        localStorage.setItem('token', result.result);
        
        var token=localStorage.getItem('token');
        // var jwt_token=jwt_decode(token);
        // console.log(jwt_token.UserID);
        localStorage.setItem("UserID",result.result.UserID)
        
        this.userId=localStorage.getItem("UserID")
        console.log(this.userId);
        this.router.navigateByUrl('/home');
         this.toastr.error(' login succsessful');
         this.service.profile(this.userId).subscribe(result=>{
           console.log(result,'gykrftg');
         },err=>{
           console.log(err,"hjtytytyty");
         }
         )
        alert('login succsessful');
      },
      err => {
        if (err.status == 400)
          this.toastr.error(' Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
          this.toastr.error(' Incorrect username or password.', 'Authentication failed.');
      }
    );
  }

  public socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform == "facebook") {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    }
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        console.log(socialPlatform+" sign in data : " , userData);
        console.log(userData.email,"email from fb")
        this.service.fbLogin(userData.email).subscribe((data: any) => {
        
          console.log(data.result);
          console.log(data['result']);
          
          // console.log(data.token);
          localStorage.setItem('token', data.result);
          // localStorage.setItem('email', data.user.email);
          // localStorage.setItem('firstname', data.user.firstName);
          // localStorage.setItem('lastname', data.user.lastName);
          // localStorage.setItem('profile',data.profile);        
           this.token = localStorage.getItem('token')
           this.payLoad = jwt_decode(this.token)
          // console.log(this.payLoad.UserID);
    
           localStorage.setItem('UserID', this.payLoad.UserID);
          this.router.navigate(['/home']);
    
        }, err => {
          alert("login failed");
          console.log(err);
    
        })
      }
    );
  }
}