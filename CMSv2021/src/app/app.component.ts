import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from './shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CMSv2021';
  constructor( private location: Location,private authService:AuthService ,private router: Router) { 
  }
 
  goBack() {
    // window.history.back();
    this.location.back();

    console.log( 'goBack()...' );
  }
  //logout
  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }
 
}
