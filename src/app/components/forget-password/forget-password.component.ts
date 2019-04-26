import { Component, OnInit } from '@angular/core';
import { NgForm, FormControlName, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {
  [x: string]: any;
  // [x: string]: any;
  forgetpasswordForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.forgetpasswordForm = this.formBuilder.group({
      Email: ['', Validators.email],
  } );
}
  
onSubmit() {
    this.service.forgetPassword(this.forgetpasswordForm.value).subscribe(
      (res: any) => {
        // localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/resetpassword');
         this.toastr.error('Mail has been sent to your Email Id');
      },
      
      err => {      
        if (err.status == 400)
          this.toastr.error('Wrong Email id.');
        else
          console.log(err);
      }
    );
    }
}
