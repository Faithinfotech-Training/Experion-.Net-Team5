import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  //CREATE A CONSTRUCTOR
  constructor(private authService:AuthService,
    private router:Router){}
  canActivate(
    next: ActivatedRouteSnapshot): boolean  {
      //expected role anad current role
      //excepted role from routes & current role from login
      const expectedRole = next.data.role;
      const currentRole=localStorage.getItem('ACCESS_ROLE');

      //check the condition
      if(currentRole!== expectedRole){
        this.router.navigateByUrl('login');
        return false;
      }
    return true;
    }
    
  
}
