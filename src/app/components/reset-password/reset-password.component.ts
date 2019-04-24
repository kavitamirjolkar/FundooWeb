import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  [x: string]: any;
  // service: any;
  // router: any;
  // toastr: any;
  
  Email=new FormControl();
  Password=new FormControl();
  ConfirmPassword=new FormControl();
  Token=new FormControl();
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/login');
  }
  onSubmit() {
    // console.log('value',this.Email.value,'dj  ',this.Password.value,'  ',this.ConfirmPassword.value);
 if( this.Password.value!=this.ConfirmPassword.value){
   return;
 }
    const data={
      "Email":this.Email.value,
      "token":this.Token.value,
      "Password":this.Password.value
     }

    this.service.resetPassword(data).subscribe(
      (res: any) => {
        // localStorage.setItem('token', res.token);
        // this.toastr.error("Password Changed Successfully");
        alert("Password Changed Successfully");
        this.router.navigateByUrl('/login');       
      },
      err => {
        if (err.status == 400)
          // this.toastr.error(' Email Id or Password is wrong');
         alert(' Email Id or Password is wrong');
        else
          console.log(err);
      }
    );
  }
}