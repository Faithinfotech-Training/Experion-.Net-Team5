import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Users } from './Users';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpclient:HttpClient,
    private router:Router) { }

    //Generate user by password
    getUserByPassword(user:Users):Observable<any>{
      console.log(user.UserName);
      console.log(user.Password);
      return this.httpclient.get(environment.apiUrl+"/api/login/"
      +user.UserName+"/" +user.Password);
    }
}
