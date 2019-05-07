import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import{environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class UserService {
BaseURI=environment.BaseURI;
  constructor(private formBuilder:FormBuilder, private http:HttpClient) { }
 
  formModel=this.formBuilder.group({
    UserName:['',Validators.required],
    FirstName:[''],
    LastName:[''],
    Email:['',Validators.email],
    Passwords:this.formBuilder.group({
      Password:['',[Validators.required,Validators.minLength(6)]],
      ConfirmPassword:['',Validators.required]

    },
   {validators:this.comparePasswords} )
  });

  comparePasswords(formBuilder:FormGroup){
    let  confirmPasswordCtrl=formBuilder.get('ConfirmPassword');
    if(confirmPasswordCtrl.errors==null || 'passwordMismatch' in confirmPasswordCtrl.errors){
      if(formBuilder.get('Password').value!=confirmPasswordCtrl.value)
      confirmPasswordCtrl.setErrors({passwordMismatch:true});
      else
      confirmPasswordCtrl.setErrors(null);
    }
  }
  register(){
    var body={
      UserName:this.formModel.value.UserName,
      Email:this.formModel.value.Email,
      FirstName:this.formModel.value.FirstName,
      LastName:this.formModel.value.LastName,
      Password:this.formModel.value.Passwords.Password
     
    };
   return this.http.post(this.BaseURI+'/ApplicationUser/register',body)
  }
  login(formData) {
    return this.http.post('https://localhost:44300/api/applicationuser/login', formData);
  }
  fbLogin(email){
    return this.http.post(this.BaseURI +'applicationuser/fblogin?email='+email,'')
  }

  // getUserProfile() {
  //   return this.http.get(this.BaseURI +'/UserProfile');
  // }

  forgetPassword(Email)
  {
    return this.http.post(this.BaseURI +'applicationuser/forgotpassword',Email);
  }
  resetPassword(formData)
  {
    return this.http.post(this.BaseURI+'ApplicationUser/resetpassword',formData);
  }

 profile(UserId)
 {
return this.http.get(this.BaseURI+"applicationuser/url/"+UserId);
 }
 profilePicture(path,email)
  {
return this.http.post(this.BaseURI+'applicationuser/profilepicture/'+email,path
 ,{responseType:'text'});
  }
}
