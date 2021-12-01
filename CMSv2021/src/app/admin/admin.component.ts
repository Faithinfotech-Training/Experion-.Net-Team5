import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  loggedUserName:string;
  constructor(private authService:AuthService,
    private router:Router) { }

  ngOnInit(): void {
    this.loggedUserName=localStorage.getItem("username");
  }
  //logout
  logout(){
  this.authService.logout();
  this.router.navigateByUrl('login');
  }
}
