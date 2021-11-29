import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Users} from '../shared/Users';

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
    //calling method from Authservice-Authorization
    this.authService.getUserByPassword(this.loginForm.value).subscribe(
      data=>{
        console.log(data);
      
        //check the role -- based on it redirect our application

        if(data.RoleId ===1){

          //logged as Admin

          console.log("Admin");
          //storing in localStorage/sessionstorage
          localStorage.setItem("username",data.UserName);
          localStorage.setItem("ACCESS_ROLE",data.RoleId.toString());
          sessionStorage.setItem("username",data.Username);
         // this.router.navigateByUrl('/admin');

        }

        else if(data.RoleId ===2){

          //logged as Admin

          console.log("User");
          localStorage.setItem("username",data.UserName);
          localStorage.setItem("ACCESS_ROLE",data.RoleId.toString());
          sessionStorage.setItem("username",data.Username);
          this.router.navigateByUrl('/users');

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
