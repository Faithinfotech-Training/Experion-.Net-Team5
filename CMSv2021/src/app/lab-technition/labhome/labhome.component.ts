import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-labhome',
  templateUrl: './labhome.component.html',
  styleUrls: ['./labhome.component.css']
})
export class LabhomeComponent implements OnInit {
  loggedUserName: string;

  constructor() { }

  ngOnInit(): void {
    this.loggedUserName = localStorage.getItem("username");
  }


}
