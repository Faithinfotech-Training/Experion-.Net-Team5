import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Users} from '../shared/Users';
import { Jwtresponse} from '../shared/jwtresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare variables
loginForm:FormGroup;
isSubmitted=false;
loginUser:Users=new Users();
error="";
jwtResponse: any =new Jwtresponse();

  constructor(private formBuilder:FormBuilder,
    private router:Router,private authService:AuthService) { }

  ngOnInit(): void {
    //FormGroup
  this.loginForm=this.formBuilder.group(
    {
      UserName:['',[Validators.required,Validators.minLength(2)]],
      Password:['',[Validators.required]]
  
    }
  
    );
  }
  //getting all the controls
get formControls(){
  return this.loginForm.controls;
}
//login verify credentials
loginCredentials(){
  //valid or invalid
  this.isSubmitted=true;
  console.log(this.loginForm.value);

//invalid
if(this.loginForm.invalid)
  return;

  //valid
  if(this.loginForm.valid){
    //calling method from Authservice-Authorization and authentication
   // this.authService.getUserByPassword(this.loginForm.value).subscribe(
   // this.authService.loginVerify(this.loginForm.value).subscribe(
    //this.authService.console.log();
    this.authService.getTokenByPassword
    (this.loginForm.value).subscribe(
      data=>{
        console.log(data);
         //token with roleid and name
         this.jwtResponse=data;

          localStorage.setItem("token",this.jwtResponse.token);// adding token to the local storage

          sessionStorage.setItem("token",this.jwtResponse.token);
        //check the role -- based on it redirect our application

        if(this.jwtResponse.RoleId ===1){

          //logged as Admin

          console.log("Admin");
          //storing in localStorage/sessionstorage
          localStorage.setItem("username",this.jwtResponse.UserName);
          localStorage.setItem("ACCESS_ROLE",this.jwtResponse.RoleId.toString());
          sessionStorage.setItem("username",this.jwtResponse.Username);
          this.router.navigateByUrl('/admin');

        }

        else if(this.jwtResponse.RoleId ===2){

          //logged as Doctor

          console.log("Doctor");
          localStorage.setItem("username",this.jwtResponse.UserName);
          localStorage.setItem("ACCESS_ROLE",this.jwtResponse.RoleId.toString());
          sessionStorage.setItem("username",this.jwtResponse.Username);
          this.router.navigateByUrl('/doctorlist');

        }

        else if(this.jwtResponse.RoleId ===1002){

          //logged as staff

          console.log("Staff");
          localStorage.setItem("username",this.jwtResponse.UserName);
          localStorage.setItem("ACCESS_ROLE",this.jwtResponse.RoleId.toString());
          sessionStorage.setItem("username",this.jwtResponse.Username);
          this.router.navigateByUrl('/home');

        }

        else{

          this.error ="sorry.. Invalid authorized role..This module is not authorized"

        }

      },

      
      error=>{
        this.error="invalid user name or password...try again"
      }
    );

  }

  //logout

  }

}
