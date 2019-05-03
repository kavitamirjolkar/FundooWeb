import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../service/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";

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
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  
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
        var jwt_token=jwt_decode(token);
        console.log(jwt_token.UserID);
        localStorage.setItem("UserID",jwt_token.UserID)
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
}