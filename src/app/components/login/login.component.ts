import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../service/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

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
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  
  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        console.log(res,"98459hs");
        localStorage.setItem('token', res);
        this.router.navigateByUrl('/home');
         //this.toastr.error(' login succsessful');
        alert('login succsessful');
      },
      err => {
        console.log("error msg")
        if (err.status == 400)
          this.toastr.error(' Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
          this.toastr.error(' Incorrect username or password.', 'Authentication failed.');
      }
    );
  }
}